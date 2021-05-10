using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace visit_sps
{
    static class DBHelper
    {
        private static SQLiteConnection ConexaoDB(string caminhoDB)
        {
        SQLiteConnection con;
            con = new SQLiteConnection("Data Source=" + caminhoDB);
            con.Open();
            return con;
        }

        public static DataTable ObterCat(int id, string caminhoDB)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM categoria WHERE id_cat=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }


        public static void AlterCat(Categoria c, string caminhoDB)
        {
       
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "UPDATE categoria SET icon = '" + c.icon + "', nome = '" + c.nome + "', nome_eng = '" + c.nomeEng + "' WHERE id_cat=" + c.id_local;
                    cmd.ExecuteNonQuery();
                    ConexaoDB(caminhoDB).Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }



        public static void AlterLocal(Local l, string caminhoDB)
        {
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "UPDATE local SET nome = '" + l.nome + "', desc = '" + l.desc + "', horario = '" + l.horario + "', horario_eng = '" + l.horarioEng + "', contacto = '" + l.contacto + "', morada = '" + l.morada + "', latitude = '" + l.latitude + "', longitude = '" + l.longitude + "', desc_eng = '" + l.descEng + "', trivago = '" + l.trivago + "' WHERE id_local=" + l.id;
                    cmd.ExecuteNonQuery();
                    ConexaoDB(caminhoDB).Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }

        }

        public static DataTable ObterLocal(int id, string caminhoDB)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM local WHERE id_local = " + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }

        public static DataTable RemoverLocal(int id, string caminhoDB)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM local WHERE id_local=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }

        public static DataTable RemoverCat(int id, string caminhoDB)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM categoria WHERE id_cat=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }

        public static DataTable AdicionarCat(Categoria c, string caminhoDB)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO categoria (nome, icon, nome_eng) VALUES ('" + c.nome + "','" + c.icon + "','" + c.nomeEng + "')";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }

        }

        public static DataTable AdicionarLocal(Local l, string caminhoDB)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO local(nome, desc, imageUrl, horario, contacto, latitude, longitude, morada, isBook, desc_eng, horario_eng, trivago ) VALUES('" + l.nome + "', '" + l.desc + "', '" + l.imagemUrl + "', '" + l.horario + "','" + l.contacto + "','" + l.latitude + "','" + l.longitude + "','" + l.morada + "', '" + 0 + "' ,'" + l.descEng + "','" + l.horarioEng + "','" + l.trivago + "')";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }

        }

        public static DataTable BuscarID(string caminhoDB)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM local";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }

        }

        public static DataTable BuscarIDLocalCategoria(string caminhoDB, int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "SELECT categoria.id_cat FROM categoria, local, localCategoria WHERE(local.id_local = localCategoria.id_local) AND(categoria.id_cat = localCategoria.id_cat) AND(local.id_local = '" + id + "')";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }

        }

        public static DataTable BuscarCat(string caminhoDB)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "SELECT * from categoria";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }

        }

        public static string inserirCatLocal(string caminhoDB, int id_cat, int id_local)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM localCategoria WHERE id_local = '" + id_local + "' AND id_cat = '" + id_cat + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    cmd.ExecuteNonQuery();
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    if (dt.Rows.Count == 0)
                    {
                        using (var cmd1 = ConexaoDB(caminhoDB).CreateCommand())
                        {
                            cmd1.CommandText = "INSERT INTO localCategoria (id_local, id_cat) VALUES('" + id_local + "', '" + id_cat + "')"; 
                            cmd1.ExecuteNonQuery();
                            ConexaoDB(caminhoDB).Close();
                            return "1";
                        }
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);

            }

        }
        public static string removerCatLocal(string caminhoDB, int id_cat, int id_local)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM localCategoria WHERE id_local = '" + id_local + "' AND id_cat = '" + id_cat + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    cmd.ExecuteNonQuery();
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    if (dt.Rows.Count == 1)
                    {
                        using (var cmd1 = ConexaoDB(caminhoDB).CreateCommand())
                        {
                            cmd1.CommandText = "DELETE FROM localCategoria WHERE id_local ='" + id_local + "'AND id_cat ='" + id_cat + "'";
                            cmd1.ExecuteNonQuery();
                            ConexaoDB(caminhoDB).Close();
                            return "1";
                        }
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro", ex);
            }
        }

        public static DataTable ExisteCat(string caminhoDB,string nome)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {

                    cmd.CommandText = "SELECT * FROM categoria WHERE nome = '" + nome + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }

        }

        public static DataTable ExisteLocal(string caminhoDB, string nome)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM local WHERE nome = '" + nome + "'";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }

        }

        public static DataTable ObterIDProx(string caminhoDB)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoDB(caminhoDB).CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM sqlite_sequence";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoDB(caminhoDB));
                    da.Fill(dt);
                    ConexaoDB(caminhoDB).Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }

        }

    }
}