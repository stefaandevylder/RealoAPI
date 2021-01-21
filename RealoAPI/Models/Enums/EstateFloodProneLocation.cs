namespace RealoAPI.Models {

    public enum EstateFloodProneLocation {

        /// <summary>
        /// An area that has recently had a flooding or where it is demonstrable that this happens at least once every 100 years.
        /// </summary>
        EFFECTIVE_FLOOD_PRONE_AREA,

        /// <summary>
        /// An area where no recent floodings has occurred. In extreme weather conditions, it is however possible that a flooding exists.
        /// </summary>
        POSSIBLE_FLOOD_PRONE_AREA,

        /// <summary>
        /// Not a flood prone area.
        /// </summary>
        NOT_A_FLOOD_PRONE_AREA

    }

}
