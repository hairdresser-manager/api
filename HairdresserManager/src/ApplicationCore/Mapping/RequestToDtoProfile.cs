using ApplicationCore.Contract.V1.Admin.Employee.Requests;
using ApplicationCore.Contract.V1.Admin.Service.Requests;
using ApplicationCore.Contract.V1.Admin.ServiceCategory;
using ApplicationCore.Contract.V1.Authentication.Register.Requests;
using ApplicationCore.Contract.V1.Client.Appointment.Requests;
using ApplicationCore.Contract.V1.Employee.Appointment.Requests;
using ApplicationCore.Contract.V1.User.Account.Requests;
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

            CreateMap<CreateEmployeeAppointmentRequest, AppointmentDto>();
        }
    }
}