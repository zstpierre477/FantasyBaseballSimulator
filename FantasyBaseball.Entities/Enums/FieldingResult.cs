namespace FantasyBaseball.Entities.Enums
{
    public enum FieldingResult
    {
        Single,
        Double,
        Triple,
        Homerun,
        OneBaseError,
        TwoBaseError,
        ThreeBaseError,
        // lead forced runner is out, others hold
        Groundout,
        // batter is out, runners advance
        GroundoutAllAdvance,
        // double play if possible, others advance
        GroundoutDoublePlay,
        // lead runner is out, others advance
        GroundoutFieldersChoice,
        // lead forced runner is out, others advance
        GroundoutFieldersChoiceForce,
        // batter is out, runners hold
        Popout,
        // batter is out, runners hold
        Lineout,
        // batter is out, and lead runner
        LineoutDoublePlay,
        // batter is out and all runners
        LineoutMaxOuts,
        // batter is out, runners hold
        Flyout,
        // batter is out, runners advance
        FlyoutAllAdvance,
        // batter is out, only runner on third advances
        FlyoutSacrifice,
        // batter is out, runners hold
        Foulout
    }
}
