using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;
using ProducaoAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProducaoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        string sqlConnectionString = "Data Source=localhost\\MEIBI2025;Initial Catalog=Producao;Integrated Security=True;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //// GET: api/<Values>
        //[HttpGet]
        //public ActionResult Get()
        //{
        //    try
        //    {
        //        Console.Write("GET Request");
        //        List<Produto> produtos = new List<Produto>();
        //        using (SqlConnection con = new SqlConnection(sqlConnectionString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("sp_GetProdutos", con))
        //            {
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                con.Open();
        //                SqlDataReader reader = cmd.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    Produto item = new Produto();
        //                    item.ID_Produto = Convert.ToInt32(reader["ID_Produto"]);
        //                    item.Codigo_Peca = Convert.ToString(reader["Codigo_Peca"]);
        //                    item.Data_Producao = Convert.ToDateTime(reader["Data_producao"]);
        //                    item.Hora_Producao = TimeSpan.Parse(reader["Hora_Producao"].ToString());
        //                    item.Tempo_Producao = Convert.ToInt32(reader["Tempo_Producao"]);
        //                    produtos.Add(item);
        //                }
        //                con.Close();

        //                return Ok(produtos);
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return BadRequest();
        //    }

        //}
        // POST api/<Values>
        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            try
            {
                Console.WriteLine("POST Request - Inserir Produto");

                using (SqlConnection con = new SqlConnection(sqlConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InserirProduto", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Codigo_Peca", produto.Codigo_Peca);
                        cmd.Parameters.AddWithValue("@Data_Producao", produto.Data_Producao);
                        cmd.Parameters.AddWithValue("@Hora_Producao", produto.Hora_Producao);
                        cmd.Parameters.AddWithValue("@Tempo_Producao", produto.Tempo_Producao);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        return Created("", new { message = "Produto inserido com sucesso! Teste e Custos gerados automaticamente." });
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao inserir produto: {ex.Message}");
                return BadRequest(new { message = "Erro ao inserir produto no SQL Server." });
            }
        }


        // PUT api/<Values>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {  
            try
            {
                Console.WriteLine($"PUT Request - Atualizar Produto ID: {id}");

                using (SqlConnection con = new SqlConnection(sqlConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateProduto", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Produto", id);
                        cmd.Parameters.AddWithValue("@Codigo_Peca", produto.Codigo_Peca);
                        cmd.Parameters.AddWithValue("@Data_Producao", produto.Data_Producao);
                        cmd.Parameters.AddWithValue("@Hora_Producao", produto.Hora_Producao);
                        cmd.Parameters.AddWithValue("@Tempo_Producao", produto.Tempo_Producao);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            return Ok(new { message = "Produto atualizado com sucesso!" });
                        }
                        else
                        {
                            return NotFound(new { message = "Produto não encontrado." });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao atualizar produto: {ex.Message}");
                return BadRequest(new { message = "Erro ao atualizar produto no SQL Server." });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Console.WriteLine($"DELETE Request for Produto ID: {id}");

                using (SqlConnection con = new SqlConnection(sqlConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteProduto", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Produto", id);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();

                        if (rowsAffected > 0)
                        {
                            return NoContent(); 
                        }
                        else
                        {
                            return NotFound(new { message = "Produto não encontrado." });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erro ao eliminar produto: {ex.Message}");
                return BadRequest(new { message = "Erro ao eliminar produto." });
            }
        }

    }
}
