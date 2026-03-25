namespace Auto.Konfiguration.Domain.Entities
{
    public class CarConfiguration
    {
        public int Id { get; set; }
        public int EngineId { get; set; }
        public Engine? Engine { get; set; }
        public int PaintId { get; set; }
        public Paint? Paint { get; set; }
        public int RimsId { get; set; }
        public Rims? Rims { get; set; }
        public List<OptionalEquipment> OptionalEquipment { get; set; } = new();
    }
}
