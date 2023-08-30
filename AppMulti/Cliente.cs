using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace AppMulti
{
     class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }    
        public string celular { get; set;}

        MySqlConnection con = new MySqlConnection("server=sql.freedb.tech;port=3306;database=freedb_Matheus;user=freedb_Matheus Henrique;password=27F8Qu@$qW67xjg;charset=utf8");

        public List<Cliente> listacliente() 
        {
            List<Cliente> li = new List<Cliente>();
            string sql = "SELECT * FROM cliente";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())  
            {   
                Cliente c = new Cliente();
                c.id = (int)dr["id"];
                c.nome = dr["nome"].ToString();
                c.celular = dr["celular"].ToString();
                li.Add(c);         
            
            }
            dr.Close();
            con.Close();
            return li;

        
        }

        public void Inserir(string nome, string celular) 
        {
            string sql = "INSERIR INTO cliente(nome,celular) VALUES ('"+nome+"','"+celular+"')";
            if(con.State == System.Data.ConnectionState.Closed) 
            {
                con.Open();            
            }
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();


        
        }

        public void Atualizar(int id, string nome, string celular) 
        {
            string sql = "UPDATE cliente SET nome='" + nome + "', celular='" + celular + "' WHERE id='" + id + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand( sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        
        }

        public void Excluir(int id) 
        {

            string sql = "DELETE FROM cliente WHERE id='" + id + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();



        }

        public void Localizar(int id) 
        {
            string sql = "SELECT * FROM cliente WHERE id= '"+id+"'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               
                nome = dr["nome"].ToString();
                celular = dr["celular"].ToString();
              

            }
            dr.Close();
            con.Close();


        }

        public bool RegistroRepetido(string nome, string celular)         
        { 
            string sql = "SELECT * FROM cliente WHERE nome='"+nome+"' AND celular'"+celular+"'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.ExecuteNonQuery();
            var result = cmd.ExecuteScalar();
            if(result != null) 
            {
                return (int)result > 0;

            
            }
            con.Clone();
            return false;
                    

        
        }
    }
}
