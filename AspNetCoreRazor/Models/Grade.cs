namespace AspNetCoreRazor.Models
{
    public class Grade : ObjetoEscuelaBase
    {
        public Student Student { get; set; }

        public string StudentId { get; set; }

        public Assignment Assignment { get; set; }

        public string AssignmentId { get; set; }

        public float Result { get; set; }

    }
}