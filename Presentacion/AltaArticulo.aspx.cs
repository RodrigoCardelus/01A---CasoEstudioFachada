using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


using EntidadesCompartidas;
using Logica;

public partial class AltaArticulo : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //primer acceso a la pagina
            Session["Articulo"] = null;
            this.DesActivoBotones();
            this.LimpioControles();
        }

    }
    private void DesActivoBotones()
    {
        btnAlta.Enabled = false;
        btnBaja.Enabled = false;
        btnModificar.Enabled = false;
    }

    private void LimpioControles()
    {
        txtCodigo.Text = "";
        txtNombre.Text = "";
        txtPrecio.Text = "";
        lblError.Text = "";
    }





    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            int codigo;

            try
            {
                codigo = Convert.ToInt32(txtCodigo.Text);
            }
            catch
            {

                throw new Exception("Formato incorrecto");
            }

            string nombre = txtNombre.Text.Trim();
            decimal precio = Convert.ToDecimal(txtPrecio.Text);

            EntidadesCompartidas.Articulo _unArticulo = null;
            _unArticulo = new EntidadesCompartidas.Articulo(codigo, nombre, precio);
            Logica.FachadaLogica.AgregarArticulo(_unArticulo);
            this.DesActivoBotones();
            this.LimpioControles();
            lblError.Text = "Alta con Exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {

            EntidadesCompartidas.Articulo _unArticulo = null;
            _unArticulo = Logica.FachadaLogica.BuscarArticulo(Convert.ToInt32(txtCodigo.Text));
            //this.LimpioControles();
            txtCodigo.Enabled = false;
            if (_unArticulo == null)
            {
                btnAlta.Enabled = true;
            }
            else
            {
                btnModificar.Enabled = true;
                btnBaja.Enabled = true;
                Session["Articulo"] = _unArticulo;
                txtCodigo.Text = _unArticulo.Codigo.ToString();
                txtNombre.Text = _unArticulo.Nombre;
                txtPrecio.Text = _unArticulo.Precio.ToString();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Articulo _unArticulo = (EntidadesCompartidas.Articulo)Session["Articulo"];
            _unArticulo.Nombre = txtNombre.Text.Trim();
            _unArticulo.Precio = Convert.ToDecimal(txtPrecio.Text);
            Logica.FachadaLogica.ModificarArticulo(_unArticulo);
            this.DesActivoBotones();
            this.LimpioControles();
            lblError.Text = "Modificacion con Exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }



    }

    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Articulo _unArticulo = (EntidadesCompartidas.Articulo)Session["Articulo"];
            Logica.FachadaLogica.EliminarArticulo(_unArticulo);
            this.DesActivoBotones();
            this.LimpioControles();
            lblError.Text = "Baja con Exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        DesActivoBotones();
        LimpioControles();

    }
}
