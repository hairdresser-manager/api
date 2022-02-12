using ApplicationCore.Contract.V1.Account.Requests;
using ApplicationCore.Contract.V1.Client.Appointment.Requests;
using ApplicationCore.Contract.V1.Employee.Requests;
using ApplicationCore.Contract.V1.Register.Requests;
using ApplicationCore.Contract.V1.Service.Requests;
using ApplicationCore.Contract.V1.ServiceCategory;
using ApplicationCore.DTOs;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class RequestToDtoProfile : Profile
    {
        public RequestToDtoProfile()
        {
            CreateMap<RegisterRequest, UserDto>();   
            
            CreateMap<UpdateAccountRequest, UserDto>();   
            
            CreateMap<UpdateEmployeeRequest, EmployeeDto>();  
            
            CreateMap<UpdateServicesCategoryRequest, ServicesCategoryDto>();  
            
            CreateMap<CreateServiceRequest, ServiceDto>();  
            
            CreateMap<UpdateServiceRequest, ServiceDto>();  
            
            CreateMap<CreateAppointmentRequest, AppointmentDto>();  
        }
    }
}