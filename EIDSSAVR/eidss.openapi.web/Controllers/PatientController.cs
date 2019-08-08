﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eidss.model.Enums;
using eidss.openapi.bll.Bll;
using eidss.openapi.contract;
using eidss.openapi.bll.Exceptions;
using eidss.openapi.web.Utils;

namespace eidss.openapi.web.Controllers
{
    /// <summary>Human Case REST service for EIDSS Open API</summary>
    [EidssFilterAction]
    public class PatientController : ApiController
    {
        /// <summary>Get Patient by it's identifier</summary>
        /// <remarks>HTTP GET verb<br/>
        /// http://hostname/api/Patient/{id} <br/>
        /// http://hostname/api/json/Patient/{id} <br/>
        /// http://hostname/api/xml/Patient/{id} <br/>
        /// </remarks>
        /// <param name="id">Identifier of Human Case</param>
        /// <returns>Human Case</returns>
        /// <example><code>
        /// (GET) http://eidss.hostname.org/api/Patient/123457890 
        /// (GET) http://eidss.hostname.org/api/json/Patient/123457890 
        /// (GET) http://eidss.hostname.org/api/xml/Patient/123457890 
        /// </code></example>
        /// <example><code>
        /// // C#
        /// var organization = "organization";
        /// var username = "username";
        /// var language = "en";
        /// var externalSystem = ""; // optional
        /// var password = "password";
        /// var authInfo = string.Format("{0}@{1}@{2}@{3}:{4}", organization, username, language, externalSystem, password);
        /// var client = new HttpClient() { BaseAddress = new Uri("http://eidss.hostname.org/") };
        /// var basic = string.Format("Basic {0}", Convert.ToBase64String(Encoding.Default.GetBytes(authInfo)));
        /// client.DefaultRequestHeaders.Add("Authorization", basic);
        /// 
        /// var response = client.GetAsync("api/Patient/12687690000000").Result;
        /// if (response.IsSuccessStatusCode) {
        ///     var hc = response.Content.ReadAsAsync&lt;Patient&gt;().Result;
        ///     Console.WriteLine("{0}", hc.CaseID);
        ///     }
        /// else
        ///     Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        /// </code></example>
        /// <exception cref="OpenApiErrorCode.A0001">User login can't be empty</exception>
        /// <exception cref="OpenApiErrorCode.A0002">User with such login/password is not found</exception>
        /// <exception cref="OpenApiErrorCode.A0003">The database version is absent or in incorrect format</exception>
        /// <exception cref="OpenApiErrorCode.A0004">Login is locked</exception>
        /// <exception cref="OpenApiErrorCode.A0005">Password is expired</exception>
        /// <exception cref="OpenApiErrorCode.A0006">Language is not supported</exception>
        /// <exception cref="OpenApiErrorCode.A0007">External system is not supported</exception>
        /// <exception cref="OpenApiErrorCode.A0008">Login is failed (general login error)</exception>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        /// <exception cref="OpenApiErrorCode.M0003">Human Case with specified id is not found</exception>
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.Patient)]
        public Patient Get(long id)
        {
            return PatientBll.Select(id);
        }


        /// <summary>Get list of brief information of Patients</summary>
        /// <remarks>HTTP GET verb <br/>
        /// http://hostname/api/Patient/list?filter={...} <br/>
        /// http://hostname/api/json/Patient/list?filter={...} <br/>
        /// http://hostname/api/xml/Patient/list?filter={...} <br/>
        /// </remarks>
        /// <param name="filter">Filter</param>
        /// <returns>List of brief information of Patients</returns>
        /// <example><code>
        /// (GET) http://eidss.hostname.org/api/Patient/list?filter={...}
        /// (GET) http://eidss.hostname.org/api/json/Patient/list?filter={...}
        /// (GET) http://eidss.hostname.org/api/xml/Patient/list?filter={...}
        /// </code></example>
        /// <example><code>
        /// // C#
        /// var organization = "organization";
        /// var username = "username";
        /// var language = "en";
        /// var externalSystem = ""; // optional
        /// var password = "password";
        /// var authInfo = string.Format("{0}@{1}@{2}@{3}:{4}", organization, username, language, externalSystem, password);
        /// var client = new HttpClient() { BaseAddress = new Uri("http://eidss.hostname.org/") };
        /// var basic = string.Format("Basic {0}", Convert.ToBase64String(Encoding.Default.GetBytes(authInfo)));
        /// client.DefaultRequestHeaders.Add("Authorization", basic);
        /// 
        /// var filter = new PatientListFilter() { RecordID = 12345678 };
        /// var serializer = new JavaScriptSerializer();
        /// var filterJson = string.Format("?filter={0}", serializer.Serialize(filter));
        /// 
        /// HttpResponseMessage response = client.GetAsync("api/Patient/list" + filterJson).Result;
        /// if (response.IsSuccessStatusCode) {
        ///     var list = response.Content.ReadAsAsync&lt;IEnumerable&lt;PatientListItem&gt;&gt;().Result;
        ///     foreach (var p in list)
        ///         Console.WriteLine("{0}", p.CaseID);
        ///     }
        /// else
        ///     Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        /// </code></example>
        /// <exception cref="OpenApiErrorCode.A0001">User login can't be empty</exception>
        /// <exception cref="OpenApiErrorCode.A0002">User with such login/password is not found</exception>
        /// <exception cref="OpenApiErrorCode.A0003">The database version is absent or in incorrect format</exception>
        /// <exception cref="OpenApiErrorCode.A0004">Login is locked</exception>
        /// <exception cref="OpenApiErrorCode.A0005">Password is expired</exception>
        /// <exception cref="OpenApiErrorCode.A0006">Language is not supported</exception>
        /// <exception cref="OpenApiErrorCode.A0007">External system is not supported</exception>
        /// <exception cref="OpenApiErrorCode.A0008">Login is failed (general login error)</exception>
        /// <exception cref="OpenApiErrorCode.A0009">Login is required</exception>
        /// <exception cref="OpenApiErrorCode.A0010">Access is denied</exception>
        [HttpGet]
        [BindJson(typeof(PatientListFilter), "filter")]
        [EidssBasicAuthorize(SelectPermission = EIDSSPermissionObject.Patient)]
        public IEnumerable<PatientListItem> List(PatientListFilter filter)
        {
            return PatientBll.Select(filter);
        }

    }
}
