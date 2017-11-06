using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminUsuarios : System.Web.UI.Page
{
  //Variables generales de la página.
  private DataSet DsGeneral= new DataSet(); DataRow fila;
  private GestorBD.GestorBD GestorBD;         //Para manejar la BD.
  private Comunes comunes = new Comunes();     //Para manejar las rutinas de uso común.
  private String cadSql;
  private const int OK = 1;

  //Acciones iniciales.
  protected void Page_Load(object sender, EventArgs e) {

  }

  //========================================================================
  //Parte 1a: acciones relacionadas con el alta de usuarios.
  //Muestra/deshabilita los controles asociados al alta.
  protected void BtnAlta_Click(object sender, EventArgs e) {

    TxtRFC.Visible = true; TxtNombre.Visible = true;
    TxtPassw.Visible = true; DDLTipo.Visible = true;
    BtnBaja.Enabled = false; BtnCambio.Enabled = false;
    LblMensaje.Text = "Operación: Alta";
    Session["Operación"] = "Alta";
  }

  //Muestra controles adicionales según el tipo de usuario a dar de alta.
  protected void DDLTipo_SelectedIndexChanged(object sender, EventArgs e) {
    String tipo;

    tipo = DDLTipo.SelectedValue;
    LblMensaje.Text = "Tipo de usuario: " + tipo;
    if (DDLTipo.Text != "Tipo de usuario") {
      if (DDLTipo.SelectedValue == "Cli") {
        TxtDomicilio.Visible = true; TxtCat.Visible = false;
      }
      else {
        TxtDomicilio.Visible = false; TxtCat.Visible = true;
        if (DDLTipo.SelectedValue == "Emp")
          TxtCat.Text = "Base";          //Tipo de empleado.
        else
          TxtCat.Text = "Gerente";
      }
      BtnEjecuta.Enabled = true;
    }
    else {
      TxtDomicilio.Visible = false; TxtCat.Visible = false; BtnEjecuta.Enabled = false;
    }
  }

  //===============================================================
  //Alta de un nuevo usuario:
  //primeramente lo da de alta en la tabla de Usuarios, verificando antes que no exista 
  //el RFC. Después da de alta en las tablas de Clientes o Empleados, según el tipo de
  //usuario de que se trate.
  public void alta() {
    //Recupera a GerstorBD.
    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];

    //Verifica que el RFC nuevo no exista en PCUsuarios.
    cadSql = "select * from PCUsuarios where RFC='" + TxtRFC.Text+"'";
    GestorBD.consBD(cadSql, "DatosUsuario", DsGeneral);
    if (DsGeneral.Tables["DatosUsuario"].Rows.Count == 0) {
      //Si el RFC no existe, se agrega el nuevo usuario.
      cadSql = "insert into PCUsuarios values ('" + TxtRFC.Text + "','" + TxtNombre.Text +
        "','" + TxtPassw.Text + "','" + DDLTipo.SelectedValue + "')";

      if (GestorBD.altaBD(cadSql) == OK) {
        if (DDLTipo.SelectedValue == "Cli") {
          //Alta de un cliente.
          cadSql = "insert into PCClientes values('" + TxtRFC.Text +
          "','" + TxtDomicilio.Text + "')";
          if (GestorBD.altaBD(cadSql) == OK)
            LblMensaje.Text = "Inserción exitosa en Usuarios y Clientes";
          else
            LblMensaje.Text = "Error de inserción en la tabla Clientes";
        }
        else {
          //Alta de un empleado.
          cadSql = "insert into PCEmpleados values('" + TxtRFC.Text + "','" + TxtCat.Text + "')";
          if (GestorBD.altaBD(cadSql) == OK)
            LblMensaje.Text = "Inserción exitosa en Usuarios y Empleados";
          else
            LblMensaje.Text = "Error de inserción en la tabla Empleados";
        }
      }
      else
        LblMensaje.Text = "Error de inserción en la tabla de usuarios";
    }
    else
      LblMensaje.Text = "El RFC ya existe en la BD";
  }

  //=================================================================
  //Parte 2a: acciones relacionadas con la baja de un usuario.
  protected void BtnBaja_Click(object sender, EventArgs e) {

    //Lee los datos de los usuarios y muestra sus RFC en DDLUsuarios.
    leeUsuarios();

    //Oculta/deshabilita controles.
    DDLUsuarios.Visible = true;
    BtnAlta.Enabled = false; BtnCambio.Enabled = false;
    LblMensaje.Text = "Operación: Baja";
    Session["Operación"] = "Baja";
  }

  //Lee los datos de los usuarios y muestra sus RFC en el DDL de usuarios.
  //Esta rutina es usada tanto en baja, como en cambio de datos de usuarios.
  protected void leeUsuarios() {
    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
    cadSql = "select * from PCUsuarios";
    GestorBD.consBD(cadSql, "DatosUsuarios", DsGeneral);
    comunes.cargaDDL(DDLUsuarios, DsGeneral, "DatosUsuarios", "RFC");
    Session["DsGeneral"] = DsGeneral;
  }

  //=================================================================
  //Partes 2a y 3b: este método se usa tanto para la baja de un usuario, 
  //como para el cambio de datos del mismo.
  protected void DDLUsuarios_SelectedIndexChanged(object sender, EventArgs e) {
    String RFC, tipo;
    DataRow[] filas;

    if (DDLUsuarios.Text != " ") {   //Partes 2a y 3b: si corresponde, activa el botón
      BtnEjecuta.Enabled = true;     //para ejecutar la operación en cuestión.

      //Parte 3b: según el tipo de usuario, muestra los datos y controles que correspondan.
      if (Session["Operación"].ToString() == "Cambio") {
        GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
        DsGeneral = (DataSet)Session["DsGeneral"];

        //Obtiene datos del usuario elegido.
        RFC = DDLUsuarios.SelectedValue;
        filas = DsGeneral.Tables["DatosUsuarios"].Select("RFC='" + RFC + "'");
        fila = filas[0]; tipo = fila["Tipo"].ToString();
        TxtNombre.Text = fila["Nombre"].ToString(); TxtNombre.Visible = true;    //Su nombre.
        TxtPassw.Text = fila["Passw"].ToString(); TxtPassw.Visible = true;      //Su password.

        if (tipo == "Cli") {            //Datos adicionales si es cliente.
          cadSql = "select * from PCClientes where RFC='" + RFC + "'";
          GestorBD.consBD(cadSql, "DatosClientes", DsGeneral);
          fila = DsGeneral.Tables["DatosClientes"].Rows[0];
          TxtDomicilio.Text = fila["Domicilio"].ToString();
          TxtDomicilio.Visible = true;
        }

        //Conserva el tipo de usuario.
        Session["tipo"] = tipo;
      }
    }
    else
      BtnEjecuta.Enabled = false;         //Si no corresponde, deshabilita el botón.
  }

  //=================================================================
  //Baja de un usuario:
  //elimina al usuario elegido en el DDL.
  protected void baja() {
    String RFC, tipo;
    DataRow[] filas;

    //Parte 2b: acciones iniciales para la baja.
    //Determina el tipo del usuario (cliente o empleado) usando la información que ya está
    //en el DataSet.
    RFC = DDLUsuarios.SelectedValue;
    DsGeneral = (DataSet)Session["DsGeneral"];
    filas = DsGeneral.Tables["DatosUsuarios"].Select("RFC='" + RFC + "'");
    fila = filas[0]; tipo = fila["Tipo"].ToString();

    //Da de baja en Clientes o Empleados, según el tipo de usuario.
    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
    if (tipo == "Cli") {
      //===========================================
      //Parte 2c: Baja en la tabla de Clientes.
      cadSql = "delete from PCClientes where RFC='" + RFC + "'";
      if (GestorBD.bajaBD(cadSql) == OK)
        LblMensaje.Text = "Eliminación exitosa en Clientes";
      else
        LblMensaje.Text = "Error de eliminación en la tabla Clientes";
    }
    else {
      //===========================================
      //Parte 2d: Baja en la tabla de Empleados.
      cadSql = "delete from PCEmpleados where RFC='" + RFC + "'";
      if (GestorBD.bajaBD(cadSql) == OK)
        LblMensaje.Text = "Eliminación exitosa en Empleados";
      else
        LblMensaje.Text = "Error de eliminación en la tabla Empleados";
    }
    //===========================================
    //Parte 2e: Da de baja en la tabla de Usuarios.
    cadSql = "delete from PCUsuarios where RFC='" + RFC + "'";
    if (GestorBD.bajaBD(cadSql) == OK)
      LblMensaje.Text = "Eliminación exitosa en Usuarios";
    else
      LblMensaje.Text = "Error de eliminación en la tabla Usuarios";
  }

  //=================================================================
  //Parte 3a: acciones relacionadas con el cambio de datos de un usuario.
  //En todos los casos se puede cambiar el nombre y el password.
  //Si el usuario es cliente, también puede cambiarse el domicilio.
  protected void BtnCambio_Click(object sender, EventArgs e) {

    //Lee los datos de los usuarios y muestra sus RFC en DDLUsuarios.
    leeUsuarios();

    //Oculta/deshabilita controles.
    DDLUsuarios.Visible = true;
    BtnAlta.Enabled = false; BtnBaja.Enabled = false;
    LblMensaje.Text = "Operación: Cambio";
    Session["Operación"] = "Cambio";
  }

  //Parte 3c: termina de completar el cambio en los datos del usuario.
  protected void cambio() {

    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
    DsGeneral = (DataSet)Session["DsGeneral"];

    //Cambia datos en la tabla Usuarios.
    cadSql = "update PCUsuarios set Nombre= '" + TxtNombre.Text +
              "', Passw='" + TxtPassw.Text + "' where RFC='" + DDLUsuarios.Text + "'";
    if (GestorBD.cambiaBD(cadSql) == OK) {
      LblMensaje.Text = "Actualización exitosa en Usuarios";
      //Si el usuario es un cliente, también cambia el domicilio.
      if (Session["tipo"].ToString() == "Cli") {
        cadSql = "update PCClientes set Domicilio='" + TxtDomicilio.Text + "'" +
                  " where RFC='" + DDLUsuarios.Text.Trim() + "'";
        if (GestorBD.cambiaBD(cadSql) == OK)
          LblMensaje.Text = "Actualización exitosa en Clientes";
        else
          LblMensaje.Text = "Error de Actualización en la tabla Clientes";
      }
    }
    else
      LblMensaje.Text = "Error de Actualización en la tabla Usuarios";
  }

  //=====================================================================
  //Parte 4: acciones relacionadas con la ejecución de la operación elegida.
  protected void BtnEjecuta_Click(object sender, EventArgs e) {
    String oper;

    if (Page.IsValid) { 
      oper = Session["Operación"].ToString();
      switch (oper) {
        case "Alta":
          alta();
          break;
        case "Baja":
          baja();
          break;
        case "Cambio":
          cambio();
          break;
      }

      TxtRFC.Visible = false; TxtNombre.Visible = false;
      TxtPassw.Visible = false; TxtDomicilio.Visible = false; TxtCat.Visible = false;
      DDLTipo.Text = "Tipo de usuario"; DDLTipo.Visible = false; DDLUsuarios.Visible = false;
      BtnAlta.Enabled = true; BtnBaja.Enabled = true; BtnCambio.Enabled = true;
      BtnEjecuta.Enabled = false;
    }
  }


}




