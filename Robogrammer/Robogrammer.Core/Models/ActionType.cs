namespace Robogrammer.Core.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum ActionType
    {
        [Display(Name = "Go forward")]
        GoForward,

        [Display(Name = "Go backward")]
        GoBackward,

        [Display(Name = "Turn left")]
        TurnLeft,

        [Display(Name = "Turn right")]
        TurnRight,

        [Display(Name = "Wait")]
        Wait,
    }
}
