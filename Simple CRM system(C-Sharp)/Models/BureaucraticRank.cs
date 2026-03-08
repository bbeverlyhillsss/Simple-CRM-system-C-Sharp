using System.ComponentModel.DataAnnotations;



namespace Simple_CRM_system_C_Sharp_.Models
{
    public enum BureaucraticRank
    {
        [Display(Name = "Junior Paper Pusher")]
        JuniorPaperPusher,

        [Display(Name = "Senior Ink Waster")]
        SeniorInkWaster,

        [Display(Name = "Coffee Break Coordinator")]
        CoffeeBreakCoordinator,

        [Display(Name = "Master of Red Tape")]
        MasterOfRedTape,

        [Display(Name = "Supreme Denier of Requests")]
        SupremeDenier
    }
}