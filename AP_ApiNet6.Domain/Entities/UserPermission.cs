using AP_ApiNet6.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Domain.Entities
{
    public sealed class UserPermission
    {
        public UserPermission(int userId, int permissionId)
        {
            Validation(userId, permissionId);
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public User User { get; set; }
        public Permission Permission { get; set; }

        private void Validation(int userId, int permissionId)
        {
            DomainValidationException.When(userId == 0, "Id usuário deve ser informado!");
            DomainValidationException.When(permissionId == 0, "Id permissão deve ser informado!");

            UserId = userId;
            PermissionId = permissionId;

        }
    }
}
