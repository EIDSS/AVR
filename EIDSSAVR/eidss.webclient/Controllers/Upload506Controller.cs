using BLToolkit.EditableObjects;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Schema;
using eidss.web.common.Controllers;
using eidss.web.common.Utils;
using eidss.webclient.Utils;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eidss.webclient.Controllers
{
	[AuthorizeEIDSS]
	public class Upload506Controller : BvController
	{
		[HttpGet]
		public ActionResult Details(long? id)
		{
			return DetailsInternal<Upload506Master.Accessor, Upload506Master>(id, Upload506Master.Accessor.Instance(null), null, null,
				(m, a) => ObjectStorage.Using<Upload506Master, Upload506Master>(o =>
				{
					HandleMasterState(o);

					return o;
				}, ModelUserContext.ClientID, id.Value, null),
				null,
				null
				);
		}

		[HttpPost]
		public ActionResult PostFile(long id, HttpPostedFileBase fileUpload)
		{
			return ObjectStorage.Using<Upload506Master, RedirectToRouteResult>(o =>
			{
				if (fileUpload == null)
				{
					o.SetError(Translator.GetMessageString("msgUploadFileNullFile"));

					return RedirectToAction("Details", "Upload506", new { id = id });
				}

				var fileName = Path.GetFileName(fileUpload.FileName);

				o.GetItems(fileName, fileUpload.InputStream);

				return RedirectToAction("Details", "Upload506", new { id = id });
			}, ModelUserContext.ClientID, id, null);

		}

		[HttpGet]
		public ActionResult IsUploadFileEnabled(long id)
		{
			return ObjectStorage.Using<Upload506Master, JsonResult>(o =>
			{
				return Json(new { Enabled = o.IsUploadingSessionAvailable(), Message = Translator.GetMessageString("msgUploadFileSystemIsBusy") }, JsonRequestBehavior.AllowGet);
			}, ModelUserContext.ClientID, id, null);
		}

		[HttpGet]
		public ActionResult Upload506ItemGrid(long root, string name, EditableList<Upload506Item> items)
		{
			ViewBag.Upload506ItemName = name;

			ObjectStorage.Put(ModelUserContext.ClientID, root, root, name, items);
			var model = new Upload506Item.Upload506ItemGridModelList(root, items);
			return PartialView(model);
		}

		private Upload506Duplicate GetPreviousDuplicate(Upload506Master master, Upload506Duplicate currentItem)
		{
			var currentIndex = 0;
			var duplicates = GetDuplicatesForMaster(master);

			if (currentItem != null)
				currentIndex = duplicates.IndexOf(currentItem);

			return currentIndex - 1 >= 0 ? duplicates[currentIndex - 1] : duplicates[duplicates.Count - 1];
		}

		private Upload506Duplicate GetNextDuplicate(Upload506Master master, Upload506Duplicate currentItem)
		{
			var currentIndex = 0;
			var duplicates = GetDuplicatesForMaster(master);

			if (currentItem != null)
				currentIndex = duplicates.IndexOf(currentItem);

			return currentIndex + 1 < duplicates.Count ? duplicates[currentIndex + 1] : duplicates[0];
		}

		private Upload506Duplicate SetResolutionGetNextDuplicate(Upload506Master master, Upload506Duplicate currentItem, Upload506Resolution resolution)
		{
			master.SetResolutionForDuplicate(currentItem.idfCase, resolution);

			return GetNextDuplicate(master, currentItem);
		}

		private Upload506Duplicate HandleAction(Upload506Master master, Upload506Duplicate currentItem, string action)
		{
			if (string.IsNullOrWhiteSpace(action))
				return currentItem;

			var currentIndex = 0;

			switch (action.ToLower())
			{
				case "next":
					return GetNextDuplicate(master, currentItem);
				case "previous":
					return GetPreviousDuplicate(master, currentItem);
				case "createasnew":
					return SetResolutionGetNextDuplicate(master, currentItem, Upload506Resolution.Created);
				case "dismiss":
					return SetResolutionGetNextDuplicate(master, currentItem, Upload506Resolution.Dismissed);
				case "update":
					return SetResolutionGetNextDuplicate(master, currentItem, Upload506Resolution.Updated);
				default:
					return currentItem;
			}
		}

		[HttpGet]
		public ActionResult Upload506UpdatePicker(long root, long id, string duplicateAction)
		{
			return PickerInternal<Upload506Duplicate.Accessor, Upload506Duplicate, Upload506Master>(0, 1, "", Upload506Duplicate.Accessor.Instance(null), null,
				(m, a, p) =>
					ObjectStorage.Using<Upload506Master, Upload506Duplicate>(o =>
					{
						var duplicates = GetDuplicatesForMaster(o);
						var updateItem = duplicates.FirstOrDefault(i => i.idfCase == id);

						var updateItemsCount = duplicates.Count;

						var currentIndex = 0;

						updateItem = HandleAction(o, updateItem, duplicateAction);

						if (updateItem != null)
							currentIndex = duplicates.IndexOf(updateItem) + 1;

						ViewBag.UpdateItemsCount = updateItemsCount;
						ViewBag.CurrentUpdateItemIndex = currentIndex;

						return updateItem;
					},
						ModelUserContext.ClientID, root, null),
				null,
				null,
				false);
		}

		[HttpGet]
		public ActionResult DismissAllDuplicates(long root)
		{
			return ObjectStorage.Using<Upload506Master, RedirectToRouteResult>(o =>
			{
				o.DismissAllDuplicates();

				return RedirectToAction("Details", "Upload506", new { id = root });
			}, ModelUserContext.ClientID, root, null);
		}

		[HttpGet]
		public ActionResult FinalizeResolveDuplicates(long root)
		{
			return ObjectStorage.Using<Upload506Master, RedirectToRouteResult>(o =>
			{
				o.FinalizeResolveDuplicates();

				return RedirectToAction("Details", "Upload506", new { id = root });
			}, ModelUserContext.ClientID, root, null);
		}

		[HttpGet]
		public ActionResult SaveUploadedData(long id)
		{
			return ObjectStorage.Using<Upload506Master, RedirectToRouteResult>(o =>
			{
				if (o.GetState() == Upload506MasterState.ReadyForSave)
				{
					try
					{
						using (var manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
						{
							Upload506Master.Accessor.Instance(null).Post(manager, o);
						}
					}
					finally
					{
						o.LeaveUploadingSession();
					}
				}

				return RedirectToAction("Details", "Upload506", new { id = id });
			}, ModelUserContext.ClientID, id, null);
		}

		[HttpGet]
		public ActionResult CancelUploadedData(long id)
		{
			return ObjectStorage.Using<Upload506Master, RedirectToRouteResult>(o =>
			{
				o.Cancel();
				o.LeaveUploadingSession();

				return RedirectToAction("Details", "Upload506", new { id = id });
			}, ModelUserContext.ClientID, id, null);
		}

		private string GetContentType(string fileName)
		{
			var ext = Path.GetExtension(fileName);

			switch (ext)
			{
				case "xlsx":
					return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
				case "xls":
					return "application/vnd.ms-excel";
				case "dbf":
					return "application/x-dbase";
				case "mdb":
					return "application/x-msaccess";
				default:
					return "application/octet-stream";
			}
		}

		[HttpGet]
		public FileResult GetErrorsFile(long id)
		{
			return ObjectStorage.Using<Upload506Master, FileResult>(o =>
			{
				var fileName = o.GetErrorFileName();
				var contentType = GetContentType(fileName);

				var byteArray = o.ErrorsFile != null ? o.ErrorsFile.ToArray() : new byte[] { };

				return File(byteArray, contentType, fileName);
			}, ModelUserContext.ClientID, id, null);
		}

		[HttpGet]
		public FileResult GetResultFile(long id)
		{
			return ObjectStorage.Using<Upload506Master, FileResult>(o =>
			{
				var fileName = o.GetResultFileName();
				var contentType = GetContentType(fileName);

				var byteArray = o.ResultFile != null ? o.ResultFile.ToArray() : new byte[] { };

				return File(byteArray, contentType, fileName);

			}, ModelUserContext.ClientID, id, null);
		}

		private void HandleMasterReadyForSave(Upload506Master master)
		{
			if (master.GetState() != Upload506MasterState.ReadyForSave)
				return;

			master.EnterUploadingSession();
		}

		private void HandleMasterWithDuplicates(Upload506Master master)
		{
			if (master.GetState() != Upload506MasterState.HasDuplicates)
				return;
		}

		private void HandleValidatedMaster(Upload506Master master)
		{
			if (master.GetState() != Upload506MasterState.ReadyForCheckDuplicates)
				return;

			master.EnterUploadingSession();

			bool validationResult = master.CheckForDuplicates();

			if (!validationResult)
			{
				HandleMasterWithDuplicates(master);
				return;
			}

			HandleMasterReadyForSave(master);
		}


		private void HandleNotValidatedMaster(Upload506Master master)
		{
			if (master.GetState() != Upload506MasterState.ReadyForValidation)
				return;

			bool validationResult = master.ValidateItems();

			if (!validationResult)
			{
				return;
			}

			HandleValidatedMaster(master);
		}

		private void HandleMasterState(Upload506Master master)
		{
			switch (master.GetState())
			{
				case Upload506MasterState.ReadyForValidation:
					HandleNotValidatedMaster(master);
					break;
				case Upload506MasterState.ReadyForCheckDuplicates:
					HandleValidatedMaster(master);
					break;
				case Upload506MasterState.HasDuplicates:
					HandleMasterWithDuplicates(master);
					break;
				case Upload506MasterState.ReadyForSave:
					HandleMasterReadyForSave(master);
					break;
			}
		}

		public static IList<Upload506Duplicate> GetDuplicatesForMaster(Upload506Master master)
		{
			if (master.GetState() != Upload506MasterState.HasDuplicates && master.GetState() != Upload506MasterState.HasDuplicatesResolutionErrors)
				return new List<Upload506Duplicate>();

			if (master.GetState() == Upload506MasterState.HasDuplicates)
				return master.Duplicates;

			return master.Duplicates.Where(d => !d.Resolved).ToList();
		}
	}
}
