using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShop_Api.Models
{
    public class VeterinarianModel
    {
        [Key]
        public long IdVeterinarian {get; set;}
        public long IdUser{get;set;}

        public UserModel User {get;set;}

        public List<Specialties_VetsModel> Specialties_Vets {get;set;}

        public List<AppointmentModel> Appointments {get;set;}
    }
}