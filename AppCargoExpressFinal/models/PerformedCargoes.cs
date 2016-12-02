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
    public class PerformedCargoes
    {

        private string usuario;
        private string fecha;
        private string origenDestino;
        private string tipoCarga;
        private string monto;
        
        public PerformedCargoes(string usuario, string fecha, string origenDestino,string tipoCarga, string monto)
        {
            this.usuario = usuario;
            this.fecha = fecha;
            this.origenDestino = origenDestino;
            this.tipoCarga = tipoCarga;
            this.monto = monto;
        } 

        public string getUsuario()
        {
            return usuario;
        }

        public void setUsuario(string usuario)
        {
            this.usuario = usuario;
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

        public string getTipoCarga()
        {
            return tipoCarga;
        }

        public void setTipoCarga(string tipoCarga)
        {
            this.tipoCarga = tipoCarga;
        }

        public string getMonto()
        {
            return monto;
        }

        public void setMonto(string monto)
        {
            this.monto = monto;
        }
    }
}