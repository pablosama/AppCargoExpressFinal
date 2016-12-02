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

namespace AppCargoExpressFinal.DataModels
{
    public class DataModels
    {

        public class Usuario
        {
            public string alias { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public int tipoUsuario { get; set; }
            public string telefonoMovil { get; set; }
            public string codigoArea { get; set; }
            public string mail { get; set; }
            public string comuna { get; set; }
            public string direccion { get; set; }
            public DateTime fechaCreacion { get; set; }
            public DateTime fechaActualizacion { get; set; }
            public string contrasena { get; set; }

            public Usuario(string alias, string contrasena, string nombre, string apellido, int tipoUsuario, string telefonoMovil, string codigoArea, string mail, string comuna, string direccion, DateTime fechaCreacion, DateTime fechaActualizacion)
            {
                this.alias = alias;
                this.nombre = nombre;
                this.apellido = apellido;
                this.tipoUsuario = tipoUsuario;
                this.telefonoMovil = telefonoMovil;
                this.codigoArea = codigoArea;
                this.mail = mail;
                this.comuna = comuna;
                this.direccion = direccion;
                this.fechaCreacion = fechaCreacion;
                this.fechaActualizacion = fechaActualizacion;
                this.contrasena = contrasena;
            }
        }



        public List<Usuario> GetUsuarios()        
        {
            var usuarios = new List<Usuario> {
            new Usuario("davalos","1234","Patrick","Arancibia",2,"98765432","+569","patrick.arancibia@gmail.com","Temuco","Direcci�n n�1",DateTime.Parse("2015-12-05"),DateTime.Parse("2016-06-05")),
            new Usuario("minimi","1234","Hans","Rubio",1,"94764381","+569","hans.rubio@gmail.com","Talca","Direcci�n n�2",DateTime.Parse("2015-07-05"),DateTime.Parse("2016-04-03")),
            new Usuario("undertaker","1234","David","Vasquez",1,"76543289","+569","david.vasquez@gmail.com","Coyhaique","Direcci�n n�3",DateTime.Parse("2015-08-01"),DateTime.Parse("2016-01-01")),
            new Usuario("evita","Pablo","1234","Romero",2,"46798725","+569","pablo.romero@gmail.com","Curacaut�n","Direcci�n n�4",DateTime.Parse("2016-10-05"),DateTime.Parse("2016-11-25")),
            new Usuario("jafar","Francisco","1234","Fernandez",2,"76543213","+569","francisco.fernandez@gmail.com","Traigu�n","Direcci�n n�5",DateTime.Parse("2010-12-03"),DateTime.Parse("2016-03-08")),
            new Usuario("palOtrolado","1234","Fernando","Lillo",1,"56781235","+569","fernando.lillo@gmail.com","Temuco","Direcci�n n�6",DateTime.Parse("2015-12-05"),DateTime.Parse("2016-06-05")),
            new Usuario("pablosama","4321","Pablo","P�rez",2,"98765432","+569","pablo.perez@gmail.com","Lautaro","Direcci�n n�7",DateTime.Parse("2016-12-05"),DateTime.Parse("2016-12-02")),
            new Usuario("huaso","1234","Angelo","Venegas",1,"65437891","+569","angelo.venegas@gmail.com","Pur�n","Direcci�n n�8",DateTime.Parse("2013-12-05"),DateTime.Parse("2016-01-08")),
            new Usuario("skynner","1234","Jaime","Vargas",1,"23458764","+569","jaime.vargas@gmail.com","Temuco","Direcci�n n�9",DateTime.Parse("2015-12-05"),DateTime.Parse("2016-03-09")),
            };
            return usuarios;
        }

        public bool UserExist(string alias, string password)
        {
            return GetUsuarios().Any(x => x.alias == alias && x.contrasena == password);          
        }

        public Usuario GetUsuerio(string alias, string password)
        {
            return GetUsuarios().FirstOrDefault(x => x.alias == alias && x.contrasena == password);
        }


        public static List<string> CargoTypes = new List<string>
        {
            "Art�culo Hogar",
            "Mudanza",
            "Veh�culos Menores",
            "Veh�culos Mayores",
            "Industial",
            "Carga Peligrosa",
            "Todas"
        };

        public static List<string> PriceRange = new List<string>
        {
            "$10.000 a $50.000",            
            "$50.000 a $70.000",
            "$70.000 a $100.000",
            "$100.000 a $150.000",
            "$150.000 a $200.000",
            "$200.000 a $300.000",
            "$300.000 a $400.000",
            "$400.000 a $500.000",
            "500.000 a $1.000.000",
            "$1.000.000 o m�s",
            "Cualquier Precio"
        };

        public static List<string> Cities = new List<string>
        {
            "Algarrobo","Alhue","Alto Biobio","Alto Del Carmen","Alto Hospicio","Ancud","Andacollo","Angol","Antofagasta","Antuco","Arauco",
            "Arica","Aysen","Buin","Bulnes","Cabildo","Cabo De Hornos","Cabrero","Calama","Calbuco","Caldera","Calera De Tango","Calle Larga",
            "Camarones","Camina","Canela","Canete","Carahue","Cartagena","Casablanca","Castro","Catemu","Cauquenes","Cerrillos","Cerro Navia",
            "Chaiten","Chanaral","Chanco","Chepica","Chiguayante","Chile Chico","Chillan","Chillan Viejo","Chimbarongo","Cholchol","Chonchi",
            "Cisnes","Cobquecura","Cochamo","Cochrane","Codegua","Coelemu","Coihueco","Coinco","Colbun","Colchane","Colina","Collipulli","Coltauco",
            "Combarbala","Concepcion","Conchali","Concon","Constitucion","Contulmo","Copiapo","Coquimbo","Coronel","Corral","Coyhaique","Cunco",
            "Curacautin","Curacavi","Curaco De Velez","Curanilahue","Curarrehue","Curepto","Curico","Dalcahue","Diego De Almagro","Donihue",
            "El Bosque","El Carmen","El Monte","El Quisco","El Tabo","Empedrado","Ercilla","Estacion Central","Florida","Freire","Freirina",
            "Fresia","Frutillar","Futaleufu","Futrono","Galvarino","General Lagos","Gorbea","Graneros","Guaitecas","Hijuelas","Hualaihue","Hualane",
            "Hualpen","Hualqui","Huara","Huasco","Huechuraba","Illapel","Independencia","Iquique","Isla De Maipo","Isla De Pascua","Juan Fernandez",
            "La Calera","La Cisterna","La Cruz","La Estrella","La Florida","La Granja","La Higuera","La Ligua","La Pintana","La Reina","La Serena",
            "La Union","Lago Ranco","Lago Verde","Laguna Blanca","Laja","Lampa","Lanco","Las Cabras","Las Condes","Lautaro","Lebu","Licanten",
            "Limache","Linares","Litueche","Llanquihue","Llay-Llay","Lo Barnechea","Lo Espejo","Lo Prado","Lolol","Loncoche","Longavi","Lonquimay",
            "Los Alamos","Los Andes","Los Angeles","Los Lagos","Los Muermos","Los Sauces","Los Vilos","Lota","Lumaco","Machali","Macul","Mafil",
            "Maipu","Malloa","Marchigue","Maria Elena","Maria Pinto","Mariquina","Maule","Maullin","Mejillones","Melipeuco","Melipilla","Molina",
            "Monte Patria","Mulchen","Nacimiento","Nancagua","Natales","Navidad","Negrete","Ninhue","Niquen","Nogales","Nueva Imperial","Nunoa",
            "Ohiggins","Olivar","Ollague","Olmue","Osorno","Ovalle","Padre Hurtado","Padre Las Casas","Paihuano","Paillaco","Paine","Palena",
            "Palmilla","Panguipulli","Panquehue","Papudo","Paredones","Parral","Pedro Aguirre Cerda","Pelarco","Pelluhue","Pemuco","Penaflor",
            "Penalolen","Pencahue","Penco","Peralillo","Perquenco","Petorca","Peumo","Pica","Pichidegua","Pichilemu","Pinto","Pirque","Pitrufquen",
            "Placilla","Portezuelo","Porvenir","Pozo Almonte","Primavera","Providencia","Puchuncavi","Pucon","Pudahuel","Puente Alto","Puerto Montt",
            "Puerto Octay","Puerto Varas","Pumanque","Punitaqui","Punta Arenas","Puqueldon","Puren","Purranque","Putaendo","Putre","Puyehue",
            "Queilen","Quellon","Quemchi","Quilaco","Quilicura","Quilleco","Quillon","Quillota","Quilpue","Quinchao","Quinta De Tilcoco","Quinta Normal",
            "Quintero","Quirihue","Rancagua","Ranquil","Rauco","Recoleta","Renaico","Renca","Rengo","Requinoa","Retiro","Rinconada","Rio Bueno",
            "Rio Claro","Rio Hurtado","Rio Ibanez","Rio Negro","Rio Verde","Romeral","Saavedra","Sagrada Familia","Salamanca","San Antonio",
            "San Bernardo","San Carlos","San Clemente","San Esteban","San Fabian","San Felipe","San Fernando","San Francisco De Mostazal",
            "San Gregorio","San Ignacio","San Javier","San Joaquin","San Jose De Maipo","San Juan De La Costa","San Miguel","San Nicolas",
            "San Pablo","San Pedro","San Pedro De Atacama","San Pedro De La Paz","San Rafael","San Ramon","San Rosendo","San Vicente","Santa Barbara",
            "Santa Cruz","Santa Juana","Santa Maria","Santiago","Santiago Oeste","Santiago Sur","Santo Domingo","Sierra Gorda","Talagante","Talca",
            "Talcahuano","Taltal","Temuco","Teno","Teodoro Schmidt","Tierra Amarilla","Til-Til","Timaukel","Tirua","Tocopilla","Tolten","Tome",
            "Torres Del Paine","Tortel","Traiguen","Trehuaco","Tucapel","Valdivia","Vallenar","Valparaiso","Vichuquen","Victoria","Vicuna",
            "Vilcun","Villa Alegre","Villa Alemana","Villarrica","Vina Del Mar","Vitacura","Yerbas Buenas","Yumbel","Yungay","Zapallar",
        };

    }
}