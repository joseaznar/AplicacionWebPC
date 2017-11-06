using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuInicio : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (Session["Tipo"].ToString().Equals("Ger"))
    {
      btnAltaPedido.Visible = false;
    }
  }

  protected void Button2_Click(object sender, EventArgs e)
  {
    Response.Redirect("AltaPedidoEmpleado.aspx");
  }

  protected void btnListaPedidos_Click(object sender, EventArgs e)
  {
    if (Session["Tipo"].ToString().Equals("Ger"))
    {
      Response.Redirect("ListaPedidosGerente.aspx");
    }
    else
    {
      Response.Redirect("ListaPedidosEmpleado.aspx");
    }
  }
}