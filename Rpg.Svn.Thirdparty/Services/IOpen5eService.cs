using System.Collections.Generic;
using System.Threading.Tasks;


using RestEase;
using Rpg.Svn.Thirdparty.Facades;

namespace Rpg.Svn.Thirdparty.Services
{

    /// <summary>
    /// This interface implements (through RestEase) calls to Open5e's API
    /// </summary>
    public interface IOpen5eService
    {
        [Get("/spells")]
        Task<List<SpellResponse>> GetSpellsAsync([Query("page")] string page);
    }
}

/*
 
    /// <summary>
            /// Authentication endpoint. Requires a TokenRequest object containing either user code and passwor or birth date, cpf and password.
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            [Post("/AppMobile.token.cls")]
            Task<TokenResponse> LoginAsync([Body] TokenRequest request);

            /// <summary>
            /// Orders endpoint. Retrieves all orders from a customer identified by unique id.
            /// </summary>
            /// <param name="clientId"></param>
            /// <param name="authToken"></param>
            /// <returns></returns>
            [Get("/AppMobile.pedido.cls")]
            Task<List<Order>> GetOrdersAsync([Query("clienteId")] string clientId, [Header("X-Hp-Auth-Token")] string authToken, [Query("origem")] string origem, [Query("")] int empresa);

            /// <summary>
            /// Tests endpoint. Retrieves all tests from a given order.
            /// </summary>
            /// <param name="clientId"></param>
            /// <param name="authToken"></param>
            /// <returns></returns>
            [Get("/AppMobile.pedido.cls")]
            Task<List<Test>> GetTestsAsync([Query("id")] string clientId, [Header("X-Hp-Auth-Token")] string authToken);

     */
