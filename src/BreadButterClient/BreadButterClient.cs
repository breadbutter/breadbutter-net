using BreadButter.Model;
using ServiceStack;
using System;

using System.Threading.Tasks;


namespace BreadButter
{
	public class BreadButterClient : IBreadButterClient
	{
		private string _baseUrl;

		private string _appId;

		private string _appSecret;

		private ServiceStack.JsonHttpClient _client;

		public BreadButterClient(string appId, string appSecret, string baseUrl = "https://api.breadbutter.io")
		{
			if (string.IsNullOrWhiteSpace(appId))
			{
				throw new BreadButterException(System.Net.HttpStatusCode.Unused, Constants.ErrorCodes.ApiError, "appId cannot be empty", null);
			}

			if (string.IsNullOrWhiteSpace(appSecret))
			{
				throw new BreadButterException(System.Net.HttpStatusCode.Unused, Constants.ErrorCodes.ApiError, "appSecret cannot be empty", null);
			}

			_baseUrl = baseUrl;
			_appId = appId;
			_appSecret = appSecret;
			_client = new ServiceStack.JsonHttpClient(_baseUrl);
			_client.AddHeader(Constants.Headers.AppSecret, appSecret);
			
		}

		private void ThrowIfNoSecret()
		{
			if (string.IsNullOrWhiteSpace(_appSecret))
			{
				throw new BreadButterException(System.Net.HttpStatusCode.Unused, Constants.ErrorCodes.ApiError, "appSecret cannot be empty", null);
			}
		}


		public async Task<GetAuthenticationResponse> GetAuthenticationAsync(string authenticationToken)
		{
			ThrowIfNoSecret();

			try
			{
				return await _client.GetAsync(new GetAuthentication() 
				{
					app_id = _appId, 
					authentication_token = authenticationToken
				});
			}
			catch (WebServiceException ex)
			{
				throw BreadButterException.GetException(ex);
			}
		}


	}
}
