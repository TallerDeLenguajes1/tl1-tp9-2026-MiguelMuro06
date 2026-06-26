namespace LectorTagMP3;

  public class Id3v1Tag
    {
        private string header;
        private string titulo;
        private string artista;
        private string album;
        private int anio;
        private string comentario;
        private string genero;

        public string Header { get => header; set => header = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Artista { get => artista; set => artista = value; }
        public string Album { get => album; set => album = value; }
        public int Anio { get => anio; set => anio = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public string Genero { get => genero; set => genero = value; }
    }