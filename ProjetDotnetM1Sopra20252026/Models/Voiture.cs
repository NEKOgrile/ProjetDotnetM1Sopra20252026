namespace ProjetDotnetM1Sopra20252026.Models
{
    public class Voiture
    {
        public int Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string Immatriculation { get; set; }
        public string AdressePropriétaire { get; set; }
    }

    public class VoitureDTO
    {
        public int Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
    }

    public static class VoitureExtension
    {
        public static VoitureDTO toDTO(this Voiture voiture)
        {
            var dto = new VoitureDTO
            {
                Id = voiture.Id,
                Marque = voiture.Marque,
                Modele = voiture.Modele
            };
            return dto;
        }
    }
}
