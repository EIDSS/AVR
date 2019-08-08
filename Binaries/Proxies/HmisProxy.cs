using System;
using Hmis.Contracts.CommonData.Contracts;
using Hmis.Rpc;
using Hmis.Rpc.Attributes;
using bv.common.Core;

namespace eidss.model.customization.Proxies
{
    public static class HmisProxy
    {
        [HmisRemoteMethod("CommonData.Hmis.CommonData.Web.Services.Managers.CommonServiceWrapper.GetPersonInfo")]
        public static PersonContract GetPersonInfo(Guid loginToken, Guid? moduleID, String personalID)
        {
            try
            {
                return RpcInvoker.InvokeMethod<PersonContract>(loginToken, moduleID, personalID);
            }
            catch(Exception ex)
            {
                LogError.Log("ErrorLog_PinService_", ex, stream =>
                {
                    stream.WriteLine(String.Format("HMIS GetPersonInfo Error: {0}", ex.Message
                        ));
                });
                throw;
            }
        }

        [HmisRemoteMethod("UserManagement.Hmis.UserManagement.Web.Services.Managers.UserManagementManager.Login")]
        public static Guid? Login(String loginName, String password, bool encryptedPassword)
        {
            try
            {
                return RpcInvoker.InvokeMethod<Guid?>(loginName, password, encryptedPassword);
            }
            catch(Exception ex)
            {
                LogError.Log("ErrorLog_PinService_", ex, stream =>
                {
                    stream.WriteLine(String.Format("HMIS Login Error: {0}", ex.Message
                        ));
                });
                throw;
            }
        }
    }
}
