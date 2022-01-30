using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class Negocio
    {
        public void NegoToPresentacio(Entidad En)
        {
            Conexion accesBD = new Conexion(En);
            accesBD.getDiario(En);
            accesBD.getPeriodo(En);
        }
    }
}
