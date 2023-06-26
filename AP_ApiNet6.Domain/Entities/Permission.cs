using AP_ApiNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AP_ApiNet6.Domain.Entities
{
    public sealed class Permission
    {
        public Permission(string visualName, string permissionName)
        {
            Validation(visualName , permissionName);
            UserPermissions = new List<UserPermission>();
        }

        public int Id { get; set; }
        public string VisualName { get; set; }
        public string PermissionName { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }

        private void Validation(string visualName, string permissionName)
        {
            DomainValidationException.When(string.IsNullOrEmpty(visualName), "Nome Visual deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(permissionName), "Nome permissão deve ser informado!");

            VisualName = visualName;
            PermissionName = permissionName;

        }
    }
}
