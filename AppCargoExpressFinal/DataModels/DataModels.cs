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
using AppCargoExpressFinal.models;

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
            public string telefonoFijo { get; set; }
            public string licenceNumber { get; set; }
            public string typOfVehicle { get; set; }
            public float ranking { get; set; }
            public int cantidadEvaluaciones { get; set; }

            public Usuario()
            {

            }

            public Usuario(
                string alias, 
                string contrasena, 
                string nombre, 
                string apellido, 
                int tipoUsuario, 
                string telefonoMovil, 
                string codigoArea, 
                string mail, 
                string comuna, 
                string direccion, 
                DateTime fechaCreacion, 
                DateTime fechaActualizacion, 
                string telefonoFijo,
                int cantidadEvaluaciones,
                string licenceNumber = "",
                string typOfVehicle = "",
                float ranking  = 0)
            {
                this.alias = alias;
                this.contrasena = contrasena;
                this.nombre = nombre;
                this.apellido = apellido;
                this.tipoUsuario = tipoUsuario;
                this.telefonoMovil = telefonoMovil;
                this.telefonoFijo = telefonoFijo;
                this.codigoArea = codigoArea;
                this.mail = mail;
                this.comuna = comuna;
                this.direccion = direccion;
                this.fechaCreacion = fechaCreacion;
                this.fechaActualizacion = fechaActualizacion;
                this.licenceNumber = licenceNumber;
                this.typOfVehicle = typOfVehicle;
                this.ranking = ranking;
                this.cantidadEvaluaciones = cantidadEvaluaciones;
            }
        }

        private List<Usuario> usuarios = new List<Usuario> {
            new Usuario("davalos","1234","Patrick","Arancibia",2,"98765432","+569","patrick.arancibia@gmail.com","Temuco","Dirección n°1",DateTime.Parse("2015-12-05"),DateTime.Parse("2016-06-05"),"225337",36,"76549684","Camioneta con Remolque",3.5f),
            new Usuario("minimi","1234","Hans","Rubio",1,"94764381","+569","hans.rubio@gmail.com","Talca","Dirección n°2",DateTime.Parse("2015-07-05"),DateTime.Parse("2016-04-03"),"225338",17,"","",4.5f),
            new Usuario("undertaker","1234","David","Vasquez",1,"76543289","+569","david.vasquez@gmail.com","Coyhaique","Dirección n°3",DateTime.Parse("2015-08-01"),DateTime.Parse("2016-01-01"),"225339",101,"","",5),
            new Usuario("evita","Pablo","1234","Romero",2,"46798725","+569","pablo.romero@gmail.com","Curacautín","Dirección n°4",DateTime.Parse("2016-10-05"),DateTime.Parse("2016-11-25"),"225340",71,"76893479","Liviano de Carga",3.5f),
            new Usuario("jafar","Francisco","1234","Fernandez",2,"76543213","+569","francisco.fernandez@gmail.com","Traiguén","Dirección n°5",DateTime.Parse("2010-12-03"),DateTime.Parse("2016-03-08"),"225341",58,"09834678","Camión Carga Pesada",4.4f),
            new Usuario("palOtrolado","1234","Fernando","Lillo",1,"56781235","+569","fernando.lillo@gmail.com","Temuco","Dirección n°6",DateTime.Parse("2015-12-05"),DateTime.Parse("2016-06-05"),"225342",67,"","",3.5f),
            new Usuario("pablosama","4321","Pablo","Pérez",2,"98765432","+569","pablo.perez@gmail.com","Lautaro","Dirección n°7",DateTime.Parse("2016-12-05"),DateTime.Parse("2016-12-02"),"225343",25,"87634912","Tractor Camión + Semi Remolque >= 5 ejes",4),
            new Usuario("huaso","1234","Angelo","Venegas",1,"65437891","+569","angelo.venegas@gmail.com","Purén","Dirección n°8",DateTime.Parse("2013-12-05"),DateTime.Parse("2016-01-08"),"225344",98,"","",2),
            new Usuario("skynner","1234","Jaime","Vargas",1,"23458764","+569","jaime.vargas@gmail.com","Temuco","Dirección n°9",DateTime.Parse("2015-12-05"),DateTime.Parse("2016-03-09"),"225345",112,"","",5),
            };

        public List<Usuario> GetUsuarios()
        {
            return usuarios;
        }

        public bool UserExist(string alias, string Name, string lastName)
        {
            return GetUsuarios().Any(x => x.alias == alias || (x.nombre == Name && x.apellido == lastName));
        }

        public Usuario GetUser(string alias, string password)
        {
            return GetUsuarios().FirstOrDefault(x => x.alias == alias && x.contrasena == password);
        }

        public void SetUser(Usuario usuario)
        {
            usuarios.Add(usuario);
        }


        public static Dictionary<int,string> CargoTypes = new Dictionary<int, string>
        {
            { 1, "Artículo Hogar" },
            { 2, "Mudanza" },
            { 3, "Vehículos Menores" },
            { 4, "Vehículos Mayores" },
            { 5, "Industial" },
            { 6, "Carga Peligrosa" },
            { 7, "Todas" }
        };

        public static Dictionary<int, string> TruckTypes = new Dictionary<int, string>
        {
            { 1, "Camioneta con Remolque"},
            { 2, "Liviano de Carga" },
            { 3, "Camión de Carga" },
            { 4, "Camión Carga Pesada" },
            { 5, "Tractor Camión + Semi Remolque >= 5 ejes" },
            { 6, "Camión + Remolque <= 4 ejes " },
            { 7, "Camión + Remolque >= 5 ejes " }
        };

        public static List<PerformedCargoes> mItems = new List<PerformedCargoes>()
        {
            new PerformedCargoes ("Esteban Dido","07/11/2016","Algarrobo - Alhue","Industial","$180.000",3.4f),
            new PerformedCargoes ("Armando Casas","05/11/2016","Pto. Montt - Santiago","Mudanza","$300.000",4.1f),
            new PerformedCargoes ("Julio Rodriguez","06/11/2016","Santiago - Arica","Artículo Hogar","$100.000",4.6f),
            new PerformedCargoes ("Beto Cuevas","07/11/2016","Coquimbo - Concepcion","Industial","$190.000",3),
            new PerformedCargoes ("Arturo Prat","08/11/2016","Concepcion - Temuco","Carga Peligrosa","$210.000",1.6f),
            new PerformedCargoes ("Pablo Neruda","16/11/2016","Osorno - Lanco","Vehículos Mayores","$90.000",3.2f),
            new PerformedCargoes ("Eduardo Oses","15/11/2016","Concepcion - Temuco","Vehículos Menores","$80.000",4.5f),
            new PerformedCargoes ("Daniel Fuentes","15/11/2016","Concepcion - Temuco","Vehículos Menores","$100.000",2.8f),
            new PerformedCargoes ("Esteban Sepúlveda","17/11/2016","Lanco - Valdivia","Carga Peligrosa","$50.000",5),
            new PerformedCargoes ("Marcos Gutierrez","18/11/2016","Valdivia - Pto. Montt","Carga Peligrosa","$230.000",4.8f),
            new PerformedCargoes ("Rodrigo Campos","19/11/2016","Pto. Montt - Chiloe","Artículo Hogar","$50.000",2),
            new PerformedCargoes ("Renier Gonzalez","20/11/2016","Pta. Arenas - Cohyaique","Mudanza","$200.000",4)
        };

        public static Dictionary<string, string> PriceRangeAndId = new Dictionary<string, string>
        {
            { "10000,50000", "$10.000 a $50.000" },
            { "50000,70000", "$50.000 a $70.000" },
            { "70000,100000", "$70.000 a $100.000" },
            { "100000,150000", "$100.000 a $150.000" },
            { "150000,200000", "$150.000 a $200.000" },
            { "200000,300000", "$200.000 a $300.000"},
            { "300000,400000", "$300.000 a $400.000"},
            { "400000,500000", "$400.000 a $500.000"},
            { "500000,1000000", "500.000 a $1.000.000"},
            { "1000000","$1.000.000 o más"},
            { "0", "Cualquier Precio"}
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