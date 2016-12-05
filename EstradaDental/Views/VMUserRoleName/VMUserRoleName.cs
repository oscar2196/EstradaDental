using EstradaDental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstradaDental.ViewModels
{
    public class VMUserRoleName
    {
        public string Id { get; set; }
        public string nombreCompleto { get; set; }
        public string email { get; set; }
        public string rolID { get; set; }

        public VMUserRoleName(ApplicationUser usr)
        {
            this.Id = usr.Id;
            this.nombreCompleto = usr.nombre + " " + usr.apellidoP;
            this.email = usr.Email;

            if (usr.Roles.Count > 0)
            {
                this.rolID = usr.Roles.First().RoleId;

            }

        }



        public VMUserRoleName()
        {



        }

    }

}