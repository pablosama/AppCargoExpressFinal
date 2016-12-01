using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppCargoExpressFinal.models
{
    public class PerformedCagoes
    {

        private int numeroOperacion;
        private string fecha;
        private string origenDestino;
        
        public PerformedCagoes(int numeroOperacion, string fecha, string origenDestino)
        {
            this.numeroOperacion = numeroOperacion;
            this.fecha = fecha;
            this.origenDestino = origenDestino;
        } 

        public int getNumeroOperacion()
        {
            return numeroOperacion;
        }

        public void setNumeroOperacion(int numeroOperacion)
        {
            this.numeroOperacion = numeroOperacion;
        }

        public string getFecha()
        {
            return fecha;
        }

        public void setFecha(string fecha)
        {
            this.fecha = fecha;
        }

        public string getOrigenDestino()
        {
            return origenDestino;
        }

        public void setOrigenDestino(string origenDestino)
        {
            this.origenDestino = origenDestino;
        }
    }
}