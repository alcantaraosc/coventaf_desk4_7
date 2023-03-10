using Api.Model.Modelos;
using Api.Model.View;
using Api.Setting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Context
{
    public class TiendaDbContext : DbContext
    {

        public TiendaDbContext() : base(ConectionContext.GetConnectionStringSqlServer())
        {
        }
        //public TiendaDbContext()
        //    : base($"Server={ConectionContext.Server}; Database={ConectionContext.DataBase}; user id={ConectionContext.User}; password={ConectionContext.Password}")
        //{
        //}

        // $"Server={ConectionContext.Server}; Database={ConectionContext.DataBase}; user id={ConectionContext.User}; password={ConectionContext.Password}");        

        //link ef6
        //https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            //Regster store procedure custom object. 

            //Especificación de la longitud máxima en una propiedad
            //modelBuilder.Entity<Department>().Property(t => t.Name).HasMaxLength(50);

            //Desactivación de identidad para claves primarias numéricas
            //modelBuilder.Entity<Department>().Property(t => t.DepartmentID)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            ////aqui le indico la ARTICULO_PRECIO despues le indico la tabla y por ultimo el esquema
            modelBuilder.Entity<Articulo_Precio>().ToTable("ARTICULO_PRECIO", "TIENDA");
            modelBuilder.Entity<Articulos>().ToTable("ARTICULO", "TIENDA");
            ///*En la base de datos se refiere a la bodega esta mal configurado*/
            modelBuilder.Entity<Vendedores>().ToTable("VENDEDOR", "TIENDA");
            modelBuilder.Entity<Cierre_Caja>().ToTable("CIERRE_CAJA", "TIENDA");
            modelBuilder.Entity<Clientes>().ToTable("CLIENTE", "TIENDA");
            modelBuilder.Entity<Consec_Caja_Pos>().ToTable("CONSEC_CAJA_POS", "TIENDA");
            modelBuilder.Entity<Consecutivo_FA>().ToTable("CONSECUTIVO_FA", "TIENDA");
            modelBuilder.Entity<Consecutivos>().ToTable("CONSECUTIVO", "TIENDA");
            modelBuilder.Entity<Existencia_Bodega>().ToTable("EXISTENCIA_BODEGA", "TIENDA");
            modelBuilder.Entity<Factura_Linea>().ToTable("FACTURA_LINEA", "TIENDA");
            modelBuilder.Entity<Facturas>().ToTable("FACTURA", "TIENDA");
            modelBuilder.Entity<Forma_Pagos>().ToTable("FORMA_PAGO", "TIENDA");
            modelBuilder.Entity<Moneda_Hist>().ToTable("MONEDA_HIST", "TIENDA");
            modelBuilder.Entity<Tipo_Tarjetas>().ToTable("TIPO_TARJETA", "TIENDA");
            modelBuilder.Entity<Condicion_Pagos>().ToTable("CONDICION_PAGO", "TIENDA");
            modelBuilder.Entity<Facturando>().ToTable("Facturando", "dbo");
            modelBuilder.Entity<Usuarios>().ToTable("USUARIO", "ERPADMIN");
            modelBuilder.Entity<RolesUsuarios>().ToTable("RolesUsuarios", "dbo");
            modelBuilder.Entity<Roles>().ToTable("Roles", "dbo");
            modelBuilder.Entity<Funciones>().ToTable("Funciones", "dbo");
            modelBuilder.Entity<FuncionesRoles>().ToTable("FuncionesRoles", "dbo");
            modelBuilder.Entity<Grupos>().ToTable("GRUPO", "TIENDA");
            modelBuilder.Entity<Grupo_Caja>().ToTable("GRUPO_CAJA", "TIENDA");
            modelBuilder.Entity<Cierre_Pos>().ToTable("CIERRE_POS", "TIENDA");
            modelBuilder.Entity<Caja_Pos>().ToTable("CAJA_POS", "TIENDA");
            modelBuilder.Entity<Cajeros>().ToTable("CAJERO", "TIENDA");
            modelBuilder.Entity<Pago_Pos>().ToTable("PAGO_POS", "TIENDA");
            modelBuilder.Entity<Nivel_Precios>().ToTable("NIVEL_PRECIO", "TIENDA");
            modelBuilder.Entity<Tipo_Tarjeta_Pos>().ToTable("TIPO_TARJETA_POS", "TIENDA");
            modelBuilder.Entity<Bodegas>().ToTable("BODEGA", "TIENDA");
            modelBuilder.Entity<FacturaBloqueada>().ToTable("FACTURA_BLOQUEADA", "dbo");
            modelBuilder.Entity<Denominacion>().ToTable("DENOMINACION", "TIENDA");
            modelBuilder.Entity<Membresia>().ToTable("MEMBRESIA", "ERPADMIN");
            modelBuilder.Entity<Cierre_Det_Pago>().ToTable("CIERRE_DET_PAGO", "TIENDA");
            modelBuilder.Entity<Entidad_Financieras>().ToTable("ENTIDAD_FINANCIERA", "TIENDA");
            modelBuilder.Entity<Retenciones>().ToTable("RETENCIONES", "TIENDA");
            modelBuilder.Entity<Factura_Retencion>().ToTable("FACTURA_RETENCION", "TIENDA");
            modelBuilder.Entity<Unidad_Fraccion>().ToTable("UNIDAD_FRACCION", "TIENDA");
            modelBuilder.Entity<Supervisores>().ToTable("SUPERVISOR", "TIENDA");

            modelBuilder.Entity<ViewFactura>().ToTable("ViewFactura", "dbo");
            modelBuilder.Entity<ViewCajaDisponible>().ToTable("ViewCajaDisponible", "dbo");
            modelBuilder.Entity<ViewUsuarios>().ToTable("ViewUsuarios", "dbo");
                       


            ////aqui le indico que la tabla ARTICULO_PRECIO su llave es el campo ARTICULO
            modelBuilder.Entity<Articulo_Precio>().HasKey(ap => new { ap.Nivel_Precio, ap.Moneda, ap.Version, ap.Articulo, ap.Version_Articulo });
            ////aqui le indico que la tabla ARTICULO su llave es el campo ARTICULO
            modelBuilder.Entity<Articulos>().HasKey(a => a.Articulo);
            ///*En la base de datos esta tabla llama vendedor, pero se refiere a la bodega*/
            modelBuilder.Entity<Vendedores>().HasKey(b => b.Vendedor);
            modelBuilder.Entity<Cierre_Caja>().HasKey(cc => new { cc.Num_Cierre_Caja, cc.Caja });
            modelBuilder.Entity<Clientes>().HasKey(c => c.Cliente);
            modelBuilder.Entity<Consec_Caja_Pos>().HasKey(ccp => new { ccp.Codigo, ccp.Caja });
            modelBuilder.Entity<Consecutivo_FA>().HasKey(cf => cf.CODIGO_CONSECUTIVO);
            modelBuilder.Entity<Consecutivos>().HasKey(c => c.CONSECUTIVO);
            modelBuilder.Entity<Existencia_Bodega>().HasKey(eb => new { eb.Articulo, eb.Bodega });
            modelBuilder.Entity<Factura_Linea>().HasKey(fl => new { fl.Factura, fl.Tipo_Documento, fl.Linea });
            modelBuilder.Entity<Facturas>().HasKey(f => new { f.Tipo_Documento, f.Factura });
            modelBuilder.Entity<Forma_Pagos>().HasKey(fp => fp.Forma_Pago);
            modelBuilder.Entity<Moneda_Hist>().HasKey(mh => new { mh.Moneda, mh.Fecha });
            modelBuilder.Entity<Tipo_Tarjetas>().HasKey(tt => tt.Tipo_Tarjeta);
            modelBuilder.Entity<Facturando>().HasKey(ft => new { ft.Factura, ft.ArticuloID });
            modelBuilder.Entity<Condicion_Pagos>().HasKey(cp => cp.Condicion_Pago);
            modelBuilder.Entity<Usuarios>().HasKey(u => u.Usuario);
            modelBuilder.Entity<RolesUsuarios>().HasKey(ru => new { ru.RolID, ru.UsuarioID });
            modelBuilder.Entity<Roles>().HasKey(r => r.RolID);
            modelBuilder.Entity<Funciones>().HasKey(f => f.FuncionID);
            modelBuilder.Entity<FuncionesRoles>().HasKey(fr => new { fr.FuncionID, fr.RolID });
            modelBuilder.Entity<Grupos>().HasKey(grp => grp.Grupo);
            modelBuilder.Entity<Grupo_Caja>().HasKey(gc => new { gc.Grupo, gc.Caja });           
            modelBuilder.Entity<Cierre_Pos>().HasKey(cp => new { cp.Num_Cierre, cp.Cajero, cp.Caja });            
            modelBuilder.Entity<Caja_Pos>().HasKey(cp => cp.Caja);
            modelBuilder.Entity<Cajeros>().HasKey(cj => cj.Cajero);
            modelBuilder.Entity<Pago_Pos>().HasKey(pp => new { pp.Documento, pp.Pago, pp.Caja, pp.Tipo });
            modelBuilder.Entity<Nivel_Precios>().HasKey(np => new { np.Nivel_Precio, np.Moneda });
            modelBuilder.Entity<Tipo_Tarjeta_Pos>().HasKey(ttp => new { ttp.Tipo_Tarjeta, ttp.Cliente, ttp.Tipo_Cobro });
            modelBuilder.Entity<Bodegas>().HasKey(b => b.Bodega);
            modelBuilder.Entity<FacturaBloqueada>().HasKey(fb => fb.NoFactura);
            modelBuilder.Entity<Denominacion>().HasKey(dm => new { dm.Tipo, dm.Denom_Monto });
            modelBuilder.Entity<Membresia>().HasKey(m => new { m.Grupo, m.Usuario });
            modelBuilder.Entity<Cierre_Det_Pago>().HasKey(cdp => new { cdp.Num_Cierre, cdp.Cajero, cdp.Caja, cdp.Tipo_Pago });
            modelBuilder.Entity<Entidad_Financieras>().HasKey(ef => ef.Entidad_Financiera);
            modelBuilder.Entity<Retenciones>().HasKey(r => r.Codigo_Retencion);
            modelBuilder.Entity<Factura_Retencion>().HasKey(fr => new { fr.Tipo_Documento, fr.Factura, fr.Codigo_Retencion });
            modelBuilder.Entity<Unidad_Fraccion>().HasKey(uf => uf.Unidad_Medida);
            modelBuilder.Entity<Supervisores>().HasKey(s => s.Supervisor);

            modelBuilder.Entity<ViewFactura>().HasKey(fct => new { fct.Tipo_Documento, fct.Factura });
            modelBuilder.Entity<ViewUsuarios>().HasKey(user => user.Usuario);
            modelBuilder.Entity<ViewCajaDisponible>().HasKey(cd => cd.Caja);

            //modelBuilder.Entity<ViewFactura>().HasNoKey().ToView("v_AreaUserInfos");
            ////vista            
            ////modelBuilder.Entity<ViewArticulo>().ToView("ViewArticulo", schema: "dbo");
            //modelBuilder.Entity<ViewFactura>().ToView("ViewFactura", schema: "dbo");
            //modelBuilder.Entity<ViewUsuarios>().ToView("ViewUsuarios", schema: "dbo");
            //modelBuilder.Entity<ViewCajaDisponible>().ToView("ViewCajaDisponible", schema: "dbo");

            //modelBuilder.Entity<ViewFactura>(c => 
            //{
            //    c.HasNoKey();
            //    c.ToView("ViewFactura");
            //});

            //           modelBuilder
            //.Entity<ProductionRatingAverage>()
            //.ToView(nameof(ProductionRatingAverages))
            //.HasKey(t => t.Id);



            //modelBuilder.Entity<Denominacion>().Property(d => d.Denom_Monto).HasPrecision(28, 8);

            //modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            //modelBuilder.Conventions.Add(new DecimalPropertyConvention(28, 8));
        }


        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Articulo_Precio> Articulo_Precio { get; set; }
        public virtual DbSet<Bodegas> Bodegas { get; set; }
        public virtual DbSet<Caja_Pos> Caja_Pos { get; set; }
        public virtual DbSet<Cajeros> Cajeros { get; set; }
        public virtual DbSet<Cierre_Caja> Cierre_Caja { get; set; }
        public virtual DbSet<Cierre_Det_Pago> Cierre_Det_Pago { get; set; }
        public virtual DbSet<Cierre_Pos> Cierre_Pos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Condicion_Pagos> Condicion_Pagos { get; set; }
        public virtual DbSet<Consec_Caja_Pos> Consec_Caja_Pos { get; set; }
        public virtual DbSet<Consecutivos> Consecutivos { get; set; }
        public virtual DbSet<Denominacion> Denominacion { get; set; }
        public virtual DbSet<Entidad_Financieras> Entidad_Financieras { get; set; }
        public virtual DbSet<Existencia_Bodega> Existencia_Bodega { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Factura_Linea> Factura_Linea { get; set; }
        public virtual DbSet<Factura_Retencion> Factura_Retencion { get; set; }
        public virtual DbSet<Forma_Pagos> Forma_Pagos { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Grupo_Caja> Grupo_Caja { get; set; }
        public virtual DbSet<Moneda_Hist> Moneda_Hist { get; set; }
        public virtual DbSet<Nivel_Precios> Nivel_Precios { get; set; }
        public virtual DbSet<Pago_Pos> Pago_Pos { get; set; }
        public virtual DbSet<Retenciones> Retenciones { get; set; }
        public virtual DbSet<Tipo_Tarjetas> Tipo_Tarjetas { get; set; }
        public virtual DbSet<Tipo_Tarjeta_Pos> Tipo_Tarjeta_Pos { get; set; }
        public virtual DbSet<Vendedores> Vendedores { get; set; }
        public virtual DbSet<Facturando> Facturando { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<RolesUsuarios> RolesUsuarios { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<FuncionesRoles> FuncionesRoles { get; set; }
        public virtual DbSet<Funciones> Funciones { get; set; }
        public virtual DbSet<FacturaBloqueada> FacturaBloqueada { get; set; }
        public virtual DbSet<Membresia> Membresia { get; set; }
        public virtual DbSet<Unidad_Fraccion> Unidad_Fraccion { get; set; }
        public virtual DbSet<Supervisores> Supervisores { get; set; }

        //vista
        //public virtual DbSet<ViewArticulo> ViewArticulo { get; set; }
        public virtual DbSet<ViewFactura> ViewFactura { get; set; }
        public virtual DbSet<ViewUsuarios> ViewUsuarios { get; set; }
        public virtual DbSet<ViewCajaDisponible> ViewCajaDisponible { get; set; }
    }
}

