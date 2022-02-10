using FluentValidation;
using HomeApi.Contracts.Models.Rooms;
using System.Linq;

namespace HomeApi.Contracts.Validation
{
    /// <summary>
    /// Класс-валидатор запросов на добавление новой комнаты
    /// </summary>
    public class AddRoomRequestValidator : AbstractValidator<AddRoomRequest>
    {
        public AddRoomRequestValidator() 
        {
            RuleFor(x => x.Area).NotEmpty(); 
            RuleFor(x => x.Name).NotEmpty().Must(BeSupported)
                 .WithMessage($"Please choose one of the following locations: {string.Join(", ", Values.ValidRooms)}"); 
            RuleFor(x => x.Voltage).NotEmpty().InclusiveBetween(120, 220);
            RuleFor(x => x.GasConnected).NotNull();
        }

        /// <summary>
        ///  Метод кастомной валидации для свойства Name
        /// </summary>
        private bool BeSupported(string location)
        {
            return Values.ValidRooms.Any(e => e == location);
        }
    }
}