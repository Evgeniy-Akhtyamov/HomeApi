using FluentValidation;
using HomeApi.Contracts.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Validation
{
    /// <summary>
    /// Класс-валидатор запросов на добавление новой комнаты
    /// </summary>
    public class UpdateRoomRequestValidator : AbstractValidator<UpdateRoomRequest>
    {
        public UpdateRoomRequestValidator()
        {
            RuleFor(x => x.NewArea).NotEmpty();
            RuleFor(x => x.NewName).NotEmpty().Must(BeSupported)
                 .WithMessage($"Please choose one of the following locations: {string.Join(", ", Values.ValidRooms)}");
            RuleFor(x => x.NewVoltage).NotEmpty().InclusiveBetween(120, 220);
            RuleFor(x => x.NewGasConnected).NotNull();
        }

        /// <summary>
        ///  Метод кастомной валидации для свойства NewName
        /// </summary>
        private bool BeSupported(string location)
        {
            return Values.ValidRooms.Any(e => e == location);
        }
    }
}
