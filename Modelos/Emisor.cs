using FacturacionDAM;
using Org.BouncyCastle.Math.EC;
using System.Data;
using System.Diagnostics;

public class Emisor
{
    public int id { get; set; }
    public string nombre { get; set; }
    public string apellidos { get; set; }
    public string nifcif { get; set; }
    public string nombreComercial { get; set; }
    public int nextNumFac { get; set; }
    public Emisor()
    {
        id = -1;
    }

    public void ActualizarEmisor(BindingSource aBs)
    {
        DataRowView? row = aBs?.Current as DataRowView;

        Debug.Assert(row != null, "Se esperaba una fila actual en (DataRowView) en el BindingSource.");

        if (row == null) return;

        int rowId = 0;
        if (!row.Row.IsNull("id"))
        {
            rowId = Convert.ToInt32(row["id"]);
        }

        if (rowId == id)
        {
            nombre = row["nombre"].ToString();
            apellidos = row["apellidos"].ToString();
            nifcif = row["nifcif"].ToString();
            nombreComercial = row["nombrecomercial"].ToString();

            if (row.Row.IsNull("nextnumfac"))
            {
                nextNumFac = 0;
            }
            else
            {
                nextNumFac = Convert.ToInt32(row["nextnumfac"]);
            }

            Program.appDAM.frmMain.RefreshStatusBar();
        }
    }
}