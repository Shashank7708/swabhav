using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace ContactAndAddressWebAPi.AuthentictionFlder
{
    // [AttributeUsage(AttributeTargets.Class,AttributeTargets.Method)]
    public class SampleJwtAuthorization : Attribute, IAuthorizationFilter
    {


        public string[] Role { get; set; }
        private ICustomTokenManager tokentManager;

        public SampleJwtAuthorization()
        {

        }

        public SampleJwtAuthorization(string[] Role)
        {
            this.Role = Role;
        }

        /// <summary>  
        /// This will Authorize User  
        /// </summary>  
        /// <returns></returns>  
        /// 
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {

            this.tokentManager = (ICustomTokenManager)filterContext.HttpContext.RequestServices.GetService(typeof(ICustomTokenManager));

            if (filterContext != null)
            {

                var token = filterContext.HttpContext.Request.Headers["token"].ToString();

                if (IsValidToken(token) && tokentManager.GetUserInfoByToken(token) != null)
                {
                    if (IsValidToken(token)){
                       string roleofuser = tokentManager.GetUserInfoByToken(token).ToUpper();
                       foreach(var i in this.Role)
                        {
                            if (i.ToUpper().Equals(roleofuser))
                            {
                                return;
                            }
                        }

                    }
                   

                }
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                filterContext.Result = new JsonResult("NotAdminRole")
                {
                    Value = new
                    {
                        Status = "Error",
                        Message = "Invalid Role or token"
                    },
                };

            }
        }

        public bool IsValidToken(string authToken)
        {
            return tokentManager.VerifyToken(authToken);
        }
    }
}
