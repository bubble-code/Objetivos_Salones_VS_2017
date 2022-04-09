using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class Negocio
    {
        public Negocio(Entidad En, string path)
        {
            Conexion accesBD = new Conexion(En, path);
            if (En._ErrorCode == 0)
            {
                accesBD.getDiario(En);
                accesBD.getPeriodo(En);
                accesBD.getMes(En);
                accesBD.getCurrent(En);
            }
            
            
        }
    }
}
