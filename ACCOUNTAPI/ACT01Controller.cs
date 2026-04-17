using ACCOUNTBAL;
using ACCOUNTMAL;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ACCOUNTAPI
{
    [ControllerName("ACT01")]
    [ApiController]
    public class ACT01Controller : ControllerBase
    {

        [HttpPost("AddAcountHolder")]
        public IActionResult AddAcountHolder([FromBody]DTOT01 objDTOT01)
        {
            Response objResponse = new Response();
            ACT01Handler objT01Handler =new ACT01Handler();
            objT01Handler.PerSave(objDTOT01);
            objResponse = objT01Handler.Insert();
            return Ok(objResponse);
        }

        [HttpPost("AddCity")]
        public IActionResult AddCity([FromBody]DTOT02 objDTOT02)
        {
            Response objResponse = new Response();
            ACT02Handler objT02Handler = new ACT02Handler();
            objT02Handler.PreSave(objDTOT02);
            objResponse = objT02Handler.Insert();
            return Ok(objResponse);
        }

        [HttpPost("Transaction")]
        public IActionResult MakeTransaction([FromBody]DTOT03 objDTOT03)
        {
            Response objResponse = new Response();
            ACT03Handler objT03Handler = new ACT03Handler();
            objT03Handler.PreSave(objDTOT03);
            objResponse = objT03Handler.Insert();
            return Ok(objResponse);
        }

        [HttpPut("UpdateAccountHolder")]
        public IActionResult UpadteAccountHolder([FromBody]DTOT01 objDTOT01)
        {
            Response objResponse = new Response();
            ACT01Handler objT01Handler = new ACT01Handler();
            objT01Handler.PerSave(objDTOT01);
            objResponse = objT01Handler.Update();
            return Ok(objResponse);
        }

        [HttpPut("UpdateCity")]
        public IActionResult UpdateCity([FromBody]DTOT02 objDTOT02)
        {
            Response objResponse = new Response();
            ACT02Handler objT02Handler = new ACT02Handler();
            objT02Handler.PreSave(objDTOT02);
            objResponse = objT02Handler.Update();
            return Ok(objResponse);
        }

        [HttpPut("UpdateTransaction")]
        public IActionResult UpdateTransaction(DTOT03 objDTOT03)
        {
            Response objResponse = new Response();
            ACT03Handler objT03Handler = new ACT03Handler();
            objT03Handler.PreSave(objDTOT03);
            objResponse = objT03Handler.Update();
            return Ok(objResponse);
        }

        [HttpDelete("DeleteAccountHolder")]
        public IActionResult DeleteAccountHolder(int acHolderId)
        {
            Response objResponse = new Response();
            ACT01Handler objT01Handler = new ACT01Handler();
            objResponse = objT01Handler.Delete(acHolderId);
            return Ok(objResponse);
        }

        [HttpDelete("DeleteCity")]
        public IActionResult DeleteCity(int cityId)
        {
            Response objResponse = new Response();
            ACT02Handler objT02Handler = new ACT02Handler();
            objResponse = objT02Handler.Delete(cityId);
            return Ok(objResponse);
        }

        [HttpDelete("DeleteTransaction")]
        public IActionResult DeleteTransaction(int transactionId)
        {
            Response objResponse = new Response();
            ACT03Handler objT03Handler = new ACT03Handler();
            objResponse = objT03Handler.Delete(transactionId);
            return Ok(objResponse);
        }

        [HttpGet("GetSummary")]
        public IActionResult GetSummary(int id)
        {
            Response objResponse = new Response();
            ACT03Handler objT03Handler = new ACT03Handler();
            objResponse = objT03Handler.Get(id);
            return Ok(objResponse);
        }
    }
}
