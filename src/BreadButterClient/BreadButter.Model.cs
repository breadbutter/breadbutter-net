/* Options:
Date: 2021-04-05 19:04:40
Version: 5.70
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://api.breadbutter.io

//GlobalNamespace: BreadButter.Model
//MakePartial: True
//MakeVirtual: True
//MakeInternal: False
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//ExportValueTypes: False
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using BreadButter.Model;


namespace BreadButter.Model
{

    [Route("/apps/{app_id}/authentications/{authentication_token}", "GET")]
    [DataContract]
    public partial class GetAuthentication
        : IReturn<GetAuthenticationResponse>, IAppId
    {
        [DataMember(IsRequired=true)]
        public virtual string app_id { get; set; }

        [DataMember(IsRequired=true)]
        public virtual string authentication_token { get; set; }
    }
    
    public partial class GetAuthenticationResponse
        : IBaseResponse
    {
        [DataMember]
        public virtual string app_id { get; set; }

        [DataMember]
        public virtual ClientDetails client_details { get; set; }

        [DataMember]
        public virtual bool auth_success { get; set; }

        [DataMember]
        public virtual string auth_error { get; set; }

        [DataMember]
        public virtual AuthenticationData auth_data { get; set; }

        [DataMember]
        public virtual GetAuthenticationProvider provider { get; set; }

        [DataMember]
        public virtual AuthOptions options { get; set; }

        [DataMember]
        public virtual string user_id { get; set; }

        [DataMember]
        public virtual IErrorResponse error { get; set; }
    }
    
    public partial class AuthenticationData
    {
        public AuthenticationData()
        {
            data = new Dictionary<string, string>{};
        }

        [DataMember]
        public virtual string email_address { get; set; }

        [DataMember]
        public virtual string first_name { get; set; }

        [DataMember]
        public virtual string last_name { get; set; }

        [DataMember]
        public virtual string profile_image_url { get; set; }

        [DataMember]
        public virtual string uid { get; set; }

        [DataMember]
        public virtual Dictionary<string, string> data { get; set; }

        [DataMember]
        public virtual AuthorizationDataTokens oauth_tokens { get; set; }
    }

    public partial class AuthOptions
    {
        [DataMember]
        public virtual string client_data { get; set; }

        [DataMember]
        public virtual string callback_url { get; set; }

        [DataMember]
        public virtual string destination_url { get; set; }

        [DataMember]
        public virtual string force_reauthentication { get; set; }
        
        [DataMember]
        public virtual string success_event_code { get; set; }
    }

    public partial class AuthorizationDataTokens
    {
        [DataMember]
        public virtual string access_token { get; set; }

        [DataMember]
        public virtual long? access_token_expires_in { get; set; }

        [DataMember]
        public virtual string refresh_token { get; set; }

        [DataMember]
        public virtual long? refresh_token_expires_in { get; set; }

        [DataMember]
        public virtual bool can_refresh_token { get; set; }

        [DataMember]
        public virtual bool can_revoke_token { get; set; }
    }

    public partial class ClientDetails
    {
        [DataMember]
        public virtual string ip_address { get; set; }

        [DataMember]
        public virtual string continent_code { get; set; }

        [DataMember]
        public virtual string continent { get; set; }

        [DataMember]
        public virtual string country_code { get; set; }

        [DataMember]
        public virtual string country { get; set; }

        [DataMember]
        public virtual string state_prov_code { get; set; }

        [DataMember]
        public virtual string state_prov { get; set; }

        [DataMember]
        public virtual string city { get; set; }

        [DataMember]
        public virtual string latitude { get; set; }

        [DataMember]
        public virtual string longitude { get; set; }

        [DataMember]
        public virtual string operating_system { get; set; }

        [DataMember]
        public virtual string browser { get; set; }

        [DataMember]
        public virtual string device { get; set; }
    }
    
    public partial class GetAuthenticationProvider
    {
        [DataMember]
        public virtual string idp { get; set; }

        [DataMember]
        public virtual string id { get; set; }

        [DataMember]
        public virtual string protocol { get; set; }

        [DataMember]
        public virtual string name { get; set; }

        [DataMember]
        public virtual string type { get; set; }
    }

    public partial interface IAppId
    {
        string app_id { get; set; }
    }

    public partial interface IBaseResponse
    {
        IErrorResponse error { get; set; }
    }

    public partial interface IErrorResponse
    {
        string code { get; set; }
        string message { get; set; }
        List<IValidationExceptionResponse> validation_errors { get; set; }
    }
    
    public partial interface IValidationExceptionResponse
    {
        string property { get; set; }
        string code { get; set; }
        string message { get; set; }
    }
}
