using FluentValidation;
using Library.DTO;

namespace Library.validition
{
    public class validator:AbstractValidator<userdto>
    {
        public validator()
        {
            RuleFor(x => x.email).EmailAddress().NotEmpty();
            RuleFor(x => x.Password).NotEmpty().Equal(x => x.ConfirnmPassword);
            RuleFor(x => x.phone).NotEmpty();
        }
    }
}
