using DynamicData;
using Nethereum.ABI.FunctionEncoding;
using NethereumBlazor.Model;
using NethereumBlazor.Services;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Threading.Tasks;

namespace NethereumBlazor.ViewModels
{
    public class OracleQueryViewModel : ReactiveObject
    {
        private readonly IOracleQueryService _oracleQueryService;
        private NewAccountPrivateKeyViewModel _newAccountPrivateKeyViewModel;

        
        public OracleQueryViewModel(IOracleQueryService oracleQueryService)
        {
            _oracleQueryService = oracleQueryService;
         
        }

        public async Task<string> SubmitOracleQuery(OracleQueryDto oracleQuery)
        {
            try
            {
                //An error occurred encoding abi value. Order: '1', Type: 'address', Value: 'null'.  Ensure the value is valid for the abi type.
                //var de = new  ParametersEncoder().EncodeParametersFromTypeAttributes()
                var queryResult = await _oracleQueryService.SubmitOracleQuery(oracleQuery);
                Console.WriteLine("submit oracle: " + JsonConvert.SerializeObject(queryResult));
                return queryResult.TransactionHash;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

      
    }
}
