using BreadButter.Model;
using System.Threading.Tasks;



namespace BreadButter
{
	public interface IBreadButterClient
	{
		Task<GetAuthenticationResponse> GetAuthenticationAsync(string authenticationToken);


	}
}