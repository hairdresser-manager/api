using System.Collections.Generic;
using ApplicationCore.DTOs;

namespace ApplicationCore.Contract.V1.Offer
{
    public class GetServiceResponse
    {
        public string CategoryName { get; set; }
        public List<ServiceDto> Services { get; set; }
    }
}