namespace ApiaryDiary.Data.Common
{
    public static class DataConstants
    {
        public static class Apiary
        {
            public const int ApiaryNameMaxLenght = 30;
            public const int ApiaryNameMinLenght = 3;
            public const int ApiaryCapacityMinLenght = 1;
            public const int ApiaryCapacityMaxLenght = 1000;
        }

        public static class Beehive
        {
            public const int BeehiveNumberMinLenght = 1;
            public const int BeehiveNumberMaxLenght = 1000;
        }

        public static class LocationInfo
        {
            public const int SettlementMaxLenght = 30;
        }

        public static class Note
        {
            public const int NoteMaxLenght = 1000;
        }

        public static class QueenBee
        {
            public const int MarkingColourLenght = 20;
            public const int OriginLenght = 20;
            public const int TemperLenght = 20;
        }
    }
}
