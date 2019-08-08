using System.Globalization;
using System.Threading;
using DevExpress.XtraPivotGrid.Localization;
using bv.common.Configuration;
using bv.common.Diagnostics;
using bv.model.Model.Core;
using bv.winclient.Layout;
using bv.winclient.Localization;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraCharts.Localization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraReports.Localization;
using DevExpress.XtraTab;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Localization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eidss.avr.mweb.Utils.Localization;

namespace bv.WinTests.Core
{
    [TestClass]
    public class DevxLocalizerTest
    {
        [TestMethod]
        //[Ignore]
        public void AddAllResources()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            DevXLocalizer.ForceResourceAdding();
            XtraWebLocalizer.ForceResourceAdding();
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            //Thread.CurrentThread.CurrentCulture  = new CultureInfo("ru-RU");
            //GlobalSettings.CurrentLanguage = GlobalSettings.lngRu;
            //DevXLocalizer.ForceResourceAdding();
        }

        [TestMethod]
        [Ignore]
        public void CheckAllUILocalizers()
        {
            Dbg.Debug(GridLocalizer.Active.GetLocalizedString(GridStringId.MenuGroupPanelShow));
            Dbg.Debug(ChartLocalizer.Active.GetLocalizedString(ChartStringId.DefaultMaxValue));
            Dbg.Debug(Localizer.Active.GetLocalizedString(StringId.Cancel));
            Dbg.Debug(BarLocalizer.Active.GetLocalizedString(BarString.RenameToolbarCaption));
            Dbg.Debug(NavBarLocalizer.Active.GetLocalizedString(NavBarStringId.NavPaneMenuAddRemoveButtons));
            Dbg.Debug(TreeListLocalizer.Active.GetLocalizedString(TreeListStringId.PrintDesignerDescription));
            //TODO разобраться
            Dbg.Debug(PivotGridLocalizer.Active.GetLocalizedString(PivotGridStringId.PopupMenuClearSorting));
            Dbg.Debug(ReportLocalizer.Active.GetLocalizedString(ReportStringId.Cmd_ViewCode));
            Dbg.Debug(PreviewLocalizer.Active.GetLocalizedString(PreviewStringId.ExportOption_HtmlExportMode));
        }

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            //DevXLocalizer.Init();
            LayoutCorrector.Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appearanceObject"></param>
        /// <param name="fontName"></param>
        private static void CheckAppearance(AppearanceObject appearanceObject, string fontName)
        {
            Assert.IsTrue(appearanceObject.Font.OriginalFontName.Equals(fontName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="language"></param>
        private static void CheckControlApperanceForLanguage(string language)
        {
            ModelUserContext.CurrentLanguage = language;
            //common.Core.Localizer.Language = language;
            LayoutCorrector.Init();
            //BaseFormManager.ShowNormal(typeof(BaseListPanelUITest), Lookup2ListItem.CreateInstance(), null, 800, 700);
            string fontName = language.Equals(common.Core.Localizer.lngGe)
                                  ? BaseSettings.GGSystemFontName
                                  : BaseSettings.SystemFontName;
            //

            //var styleController = new StyleController();
            //styleController.InitStyleController();
            //CheckAppearance(styleController.Appearance, fontName);
            //CheckAppearance(styleController.AppearanceDisabled, fontName);
            //CheckAppearance(styleController.AppearanceDropDown, fontName);
            //CheckAppearance(styleController.AppearanceDropDownHeader, fontName);
            //CheckAppearance(styleController.AppearanceFocused, fontName);
            //CheckAppearance(styleController.AppearanceReadOnly, fontName);

            //

            //var toolTipController = new DefaultToolTipController();
            //toolTipController.InitTooltipController();
            //CheckAppearance(toolTipController.DefaultController.Appearance, fontName);

            //

            var gridControl = new GridControl();
            gridControl.MainView = new GridView(gridControl);

            LayoutCorrector.ApplySystemFont(gridControl);
            //gridControl.InitXtraGridAppearance(true);
            foreach (AppearanceObject apperance in gridControl.MainView.Appearance)
            {
                CheckAppearance(apperance, fontName);
            }
            foreach (GridColumn col in ((GridView) gridControl.MainView).Columns)
            {
                CheckAppearance(col.AppearanceCell, fontName);
                CheckAppearance(col.AppearanceHeader, fontName);
            }

            //

            var tree = new TreeList();
            LayoutCorrector.ApplySystemFont(tree);
            tree.InitXtraTreeAppearance(true);
            foreach (AppearanceObject apperance in tree.Appearance)
            {
                CheckAppearance(apperance, fontName);
            }

            //

            var page = new XtraTabPage();
            LayoutCorrector.ApplySystemFont(page);
            page.InitXtraTabAppearance();
            CheckAppearance(page.Appearance.Header, fontName);
            CheckAppearance(page.Appearance.HeaderActive, fontName);
            CheckAppearance(page.Appearance.HeaderHotTracked, fontName);
            CheckAppearance(page.Appearance.HeaderDisabled, fontName);

            //

            var edit = new CheckEdit();
            LayoutCorrector.ApplySystemFont(edit);
            edit.InitCheckEditAppearance();
            CheckAppearance(edit.Properties.Appearance, fontName);
            CheckAppearance(edit.Properties.AppearanceDisabled, fontName);
            CheckAppearance(edit.Properties.AppearanceFocused, fontName);
            CheckAppearance(edit.Properties.AppearanceReadOnly, fontName);

            //

            var ctl = new GroupControl();
            LayoutCorrector.ApplySystemFont(ctl);
            ctl.InitGroupControlAppearance();
            CheckAppearance(ctl.Appearance, fontName);
            CheckAppearance(ctl.AppearanceCaption, fontName);

            //

            var controller = new DefaultBarAndDockingController();
            controller.InitBarAppearance();
            CheckAppearance(controller.Controller.AppearancesBar.Bar, fontName);
            CheckAppearance(controller.Controller.AppearancesBar.Dock, fontName);
            CheckAppearance(controller.Controller.AppearancesBar.MainMenu, fontName);
            CheckAppearance(controller.Controller.AppearancesBar.StatusBar, fontName);
            CheckAppearance(controller.Controller.AppearancesBar.SubMenu.Menu, fontName);
            CheckAppearance(controller.Controller.AppearancesBar.SubMenu.MenuBar, fontName);
            CheckAppearance(controller.Controller.AppearancesBar.SubMenu.SideStrip, fontName);
            CheckAppearance(controller.Controller.AppearancesBar.SubMenu.SideStripNonRecent, fontName);
            CheckAppearance(controller.Controller.AppearancesDocking.ActiveTab, fontName);
            CheckAppearance(controller.Controller.AppearancesDocking.FloatFormCaption, fontName);
            CheckAppearance(controller.Controller.AppearancesDocking.FloatFormCaptionActive, fontName);
            CheckAppearance(controller.Controller.AppearancesDocking.HideContainer, fontName);
            CheckAppearance(controller.Controller.AppearancesDocking.HidePanelButton, fontName);
            CheckAppearance(controller.Controller.AppearancesDocking.HidePanelButtonActive, fontName);
            CheckAppearance(controller.Controller.AppearancesDocking.Panel, fontName);
            CheckAppearance(controller.Controller.AppearancesDocking.PanelCaption, fontName);
            CheckAppearance(controller.Controller.AppearancesDocking.PanelCaptionActive, fontName);
            CheckAppearance(controller.Controller.AppearancesDocking.Tabs, fontName);

            //

            var grid = new PivotGridControl();
            LayoutCorrector.ApplySystemFont(grid);
            grid.InitPivotGridAppearance();
            foreach (AppearanceObject apperance in grid.Appearance)
            {
                CheckAppearance(apperance, fontName);
            }
            foreach (AppearanceObject apperance in grid.AppearancePrint)
            {
                CheckAppearance(apperance, fontName);
            }
            foreach (AppearanceObject apperance in grid.PaintAppearance)
            {
                CheckAppearance(apperance, fontName);
            }
            foreach (AppearanceObject apperance in grid.PaintAppearancePrint)
            {
                CheckAppearance(apperance, fontName);
            }

            //

            var bar = new NavBarControl();
            LayoutCorrector.ApplySystemFont(bar);
            bar.InitNavAppearance();
            foreach (AppearanceObject apperance in bar.Appearance)
            {
                CheckAppearance(apperance, fontName);
            }
            foreach (NavBarGroup group in bar.Groups)
            {
                CheckAppearance(group.Appearance, fontName);
                CheckAppearance(group.AppearanceBackground, fontName);
                CheckAppearance(group.AppearanceHotTracked, fontName);
                CheckAppearance(group.AppearancePressed, fontName);
            }
        }

        [TestMethod]
        [Ignore]
        public void CheckControlsApperance()
        {
            //Грузинский язык
            CheckControlApperanceForLanguage(common.Core.Localizer.lngGe);
            //дефолтный
            CheckControlApperanceForLanguage(common.Core.Localizer.lngEn);
        }
    }
}