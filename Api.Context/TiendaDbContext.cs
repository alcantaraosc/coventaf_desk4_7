using Api.Model.Modelos;
using Api.Model.View;
using Api.Setting;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Api.Context
{
    public class TiendaDbContext : DbContext
    {

        public TiendaDbContext() : base(ConectionContext.GetConnectionSqlServer())
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
            modelBuilder.Entity<Articulo_Precio>().ToTable("ARTICULO_PRECIO", User.Compañia);
            modelBuilder.Entity<Articulos>().ToTable("ARTICULO", User.Compañia);
            ///*En la base de datos se refiere a la bodega esta mal configurado*/
            modelBuilder.Entity<Vendedores>().ToTable("VENDEDOR", User.Compañia);
            modelBuilder.Entity<Cierre_Caja>().ToTable("CIERRE_CAJA", User.Compañia);
            modelBuilder.Entity<Clientes>().ToTable("CLIENTE", User.Compañia);
            modelBuilder.Entity<Consec_Caja_Pos>().ToTable("CONSEC_CAJA_POS", User.Compañia);
            modelBuilder.Entity<Consecutivo_FA>().ToTable("CONSECUTIVO_FA", User.Compañia);
            modelBuilder.Entity<Consecutivos>().ToTable("CONSECUTIVO", User.Compañia);
            modelBuilder.Entity<Existencia_Bodega>().ToTable("EXISTENCIA_BODEGA", User.Compañia);
            modelBuilder.Entity<Factura_Linea>().ToTable("FACTURA_LINEA", User.Compañia);
            modelBuilder.Entity<Facturas>().ToTable("FACTURA", User.Compañia);
            modelBuilder.Entity<Forma_Pagos>().ToTable("FORMA_PAGO", User.Compañia);
            modelBuilder.Entity<Moneda_Hist>().ToTable("MONEDA_HIST", User.Compañia);
            modelBuilder.Entity<Tipo_Tarjetas>().ToTable("TIPO_TARJETA", User.Compañia);
            modelBuilder.Entity<Condicion_Pagos>().ToTable("CONDICION_PAGO", User.Compañia);
            modelBuilder.Entity<Facturando>().ToTable("FACTURANDO", "dbo");
            modelBuilder.Entity<Usuarios>().ToTable("USUARIO", "ERPADMIN");
            modelBuilder.Entity<RolesUsuarios>().ToTable("RolesUsuarios", "dbo");
            modelBuilder.Entity<Roles>().ToTable("Roles", "dbo");
            modelBuilder.Entity<Funciones>().ToTable("Funciones", "dbo");
            modelBuilder.Entity<FuncionesRoles>().ToTable("FuncionesRoles", "dbo");
            modelBuilder.Entity<Grupos>().ToTable("GRUPO", User.Compañia);
            modelBuilder.Entity<Grupo_Caja>().ToTable("GRUPO_CAJA", User.Compañia);
            modelBuilder.Entity<Cierre_Pos>().ToTable("CIERRE_POS", User.Compañia);
            modelBuilder.Entity<Caja_Pos>().ToTable("CAJA_POS", User.Compañia);
            modelBuilder.Entity<Cajeros>().ToTable("CAJERO", User.Compañia);
            modelBuilder.Entity<Pago_Pos>().ToTable("PAGO_POS", User.Compañia);
            modelBuilder.Entity<Nivel_Precios>().ToTable("NIVEL_PRECIO", User.Compañia);
            modelBuilder.Entity<Tipo_Tarjeta_Pos>().ToTable("TIPO_TARJETA_POS", User.Compañia);
            modelBuilder.Entity<Bodegas>().ToTable("BODEGA", User.Compañia);
            modelBuilder.Entity<FacturaBloqueada>().ToTable("FACTURA_BLOQUEADA", User.Compañia);
            modelBuilder.Entity<Denominacion>().ToTable("DENOMINACION", User.Compañia);
            modelBuilder.Entity<Membresia>().ToTable("MEMBRESIA", "ERPADMIN");
            modelBuilder.Entity<Cierre_Det_Pago>().ToTable("CIERRE_DET_PAGO", User.Compañia);
            modelBuilder.Entity<Entidad_Financieras>().ToTable("ENTIDAD_FINANCIERA", User.Compañia);
            modelBuilder.Entity<Retenciones>().ToTable("RETENCIONES", User.Compañia);
            modelBuilder.Entity<Factura_Retencion>().ToTable("FACTURA_RETENCION", User.Compañia);
            modelBuilder.Entity<Unidad_Fraccion>().ToTable("UNIDAD_FRACCION", User.Compañia);
            modelBuilder.Entity<Supervisores>().ToTable("SUPERVISOR", User.Compañia);
            //Devoluciones
            modelBuilder.Entity<Auxiliar_Pos>().ToTable("AUXILIAR_POS", User.Compañia);
            modelBuilder.Entity<Cierre_Desg_Tarj>().ToTable("CIERRE_DESG_TARJ", User.Compañia);
            modelBuilder.Entity<Documento_Pos>().ToTable("DOCUMENTO_POS", User.Compañia);
            modelBuilder.Entity<Doc_Pos_Linea>().ToTable("DOC_POS_LINEA", User.Compañia);            
            modelBuilder.Entity<Cs_Bitacora_Visita>().ToTable("CS_BITACORA_VISITA", User.Compañia);
            modelBuilder.Entity<Cs_Acompanante>().ToTable("CS_ACOMPANANTE", User.Compañia);
            modelBuilder.Entity<Monedas>().ToTable("MONEDA", User.Compañia);
            modelBuilder.Entity<Proveedores>().ToTable("PROVEEDOR", User.Compañia);
            //modelBuilder.Entity<Globales_co>().ToTable("GLOBALES_CO", User.Compañia);
            modelBuilder.Entity<Order_Compras>().ToTable("ORDEN_COMPRA", User.Compañia);
            modelBuilder.Entity<U_Procedencia>().ToTable("U_PROCEDENCIA", User.Compañia);

            modelBuilder.Entity<Orden_Compra_Lineas>().ToTable("ORDEN_COMPRA_LINEA", User.Compañia);
            modelBuilder.Entity<Orden_Compras>().ToTable("ORDEN_COMPRAS", "dbo");
            modelBuilder.Entity<Detalle_Orden_Compra>().ToTable("DETALLE_ORDEN_COMPRA", "dbo");
            modelBuilder.Entity<Recepcion_Orden>().ToTable("RECEPCION_ORDEN", "dbo");
            modelBuilder.Entity<Detalle_Recepcion_Orden>().ToTable("DETALLE_RECEPCION_ORDEN", "dbo");
            modelBuilder.Entity<Tipo_Estado>().ToTable("TIPO_ESTADO", "dbo");
          

            modelBuilder.Entity<ViewFactura>().ToTable("ViewFactura", User.Compañia);
            modelBuilder.Entity<ViewCajaDisponible>().ToTable("ViewCajaDisponible", User.Compañia);            
            modelBuilder.Entity<ViewDevoluciones>().ToTable("ViewDevoluciones", User.Compañia);
            modelBuilder.Entity<ViewRecibo>().ToTable("ViewRecibo", User.Compañia);



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
            modelBuilder.Entity<Auxiliar_Pos>().HasKey(ap => new { ap.Docum_Aplica, ap.Tipo_Aplica, ap.Caja_Docum_Aplica, ap.Documento, ap.Tipo, ap.Caja });
            modelBuilder.Entity<Cierre_Desg_Tarj>().HasKey(cdt => new { cdt.Num_Cierre, cdt.Cajero, cdt.Caja, cdt.Consecutivo });
            modelBuilder.Entity<Documento_Pos>().HasKey(dp => new { dp.Documento, dp.Tipo, dp.Caja });
            modelBuilder.Entity<Doc_Pos_Linea>().HasKey(dpl => new { dpl.Documento, dpl.Tipo, dpl.Caja, dpl.Linea });
            modelBuilder.Entity<Cs_Bitacora_Visita>().HasKey(nv => nv.Numero_Visita);
            modelBuilder.Entity<Cs_Acompanante>().HasKey(ac => ac.Id);
            modelBuilder.Entity<Monedas>().HasKey(m => m.Moneda);
            modelBuilder.Entity<Proveedores>().HasKey(p => p.Proveedor);
            //modelBuilder.Entity<Globales_co>().HasKey(g => g.Id);
            modelBuilder.Entity<Order_Compras>().HasKey(oc => oc.Orden_Compra);
            modelBuilder.Entity<Orden_Compra_Lineas>().HasKey(ocl => new { ocl.Orden_Compra, ocl.Orden_Compra_Linea });
            modelBuilder.Entity<Orden_Compras>().HasKey(oc => oc.Orden_Compra);

            //modelBuilder.Entity<Detalle_Orden_Compra>().HasKey(doc => new { doc.Orden_Compra, doc.Linea });
            //modelBuilder.Entity<Recepcion_Orden>().HasKey(ro => ro.Orden_Compra);
            //modelBuilder.Entity<Detalle_Recepcion_Orden>().HasKey(dro => new { dro.Orden_Compra, dro.Linea });
            //modelBuilder.Entity<Tipo_Estado>().HasKey(te => te.Estado_ID);

            modelBuilder.Entity<U_Procedencia>().HasKey(p => p.U_Codigo);
                        
            modelBuilder.Entity<ViewFactura>().HasKey(fct => new { fct.Tipo_Documento, fct.Factura });            
            modelBuilder.Entity<ViewCajaDisponible>().HasKey(cd => cd.Caja);
            modelBuilder.Entity<ViewDevoluciones>().HasKey(dv => new { dv.Factura, dv.Tipo_Documento });
            modelBuilder.Entity<ViewRecibo>().HasKey(rb => new { rb.Factura, rb.Tipo_Documento, rb.Caja });

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

            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(28, 4));
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
        public virtual DbSet<Auxiliar_Pos> Auxiliar_Pos { get; set; }
        public virtual DbSet<Cierre_Desg_Tarj> Cierre_Desg_Tarj { get; set; }
        public virtual DbSet<Documento_Pos> Documento_Pos { get; set; }
        public virtual DbSet<Doc_Pos_Linea> Doc_Pos_Linea { get; set; }
        
        public virtual DbSet<Cs_Bitacora_Visita> Cs_Bitacora_Visita { get; set; }
        public virtual DbSet<Cs_Acompanante> Cs_Acompanante { get; set; }

        public virtual DbSet<Monedas> Monedas { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<Globales_co> Globales_co { get; set; }
        public virtual DbSet<Order_Compras> Order_Compra { get; set; }
        public virtual DbSet<Orden_Compra_Lineas> Orden_Compra_Lineas { get; set; }
        public virtual DbSet<Orden_Compras> Orden_Compra { get; set; }
        public virtual DbSet<Detalle_Orden_Compra> Detalle_Orden_Compra { get; set; }
        public virtual DbSet<Recepcion_Orden> Recepcion_Orden { get; set; }
        public virtual DbSet<Detalle_Recepcion_Orden> Detalle_Recepcion_Orden { get; set; }
        public virtual DbSet<Tipo_Estado> Tipo_Estado { get; set; }
        public virtual DbSet<U_Procedencia> U_Procedencia { get; set; }

        //vista
        //public virtual DbSet<ViewArticulo> ViewArticulo { get; set; }
        public virtual DbSet<ViewFactura> ViewFactura { get; set; }        
        public virtual DbSet<ViewCajaDisponible> ViewCajaDisponible { get; set; }
        public virtual DbSet<ViewDevoluciones> ViewDevoluciones { get; set; }
        public virtual DbSet<ViewRecibo> ViewRecibo { get; set; }
    }
}

