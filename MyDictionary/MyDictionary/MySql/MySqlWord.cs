using MyDictionary.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;


namespace MyDictionary.MySql
{
    class MySqlWord
    {
        public List<Word> LoadData()
        {
            List<Word> wordsList = new List<Word>();

            using (MySqlConnection conn = new DataBaseConnector().GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM word WHERE `delete`= 0", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "word");

                if (ds.Tables["word"] != null && ds.Tables["word"].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables["word"].Rows)
                    {
                        Word word = new Word();
                        word.Id = Convert.ToInt32(row["id"]);
                        word.Content = row["content"].ToString();
                        word.Translation = row["translation"].ToString();
                        word.Idiom = Convert.ToBoolean(row["idiom"]);
                        word.NumPass = Convert.ToInt32(row["numPass"]);
                        word.NumTested = Convert.ToInt32(row["numTested"]);
                        word.like = Convert.ToBoolean(row["like"]);
                        wordsList.Add(word);
                    }
                }
            }
            return wordsList;
        }

        public void InsertData(Word word)
        {
            using (MySqlConnection conn = new DataBaseConnector().GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO word (content, translation, idiom, numPass, numTested) VALUES (@content, @translation, @idiom, @numPass, @numTested)", conn);

                // Assuming the Word class properties correspond to the columns in the "word" table
                cmd.Parameters.AddWithValue("@content", word.Content);
                cmd.Parameters.AddWithValue("@translation", word.Translation);
                cmd.Parameters.AddWithValue("@idiom", word.Idiom); // Assuming word.Idiom is a boolean
                cmd.Parameters.AddWithValue("@numPass", word.NumPass);
                cmd.Parameters.AddWithValue("@numTested", word.NumTested);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateNumPass(int wordId, int newNumPassValue)
        {
            using (MySqlConnection conn = new DataBaseConnector().GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE word SET numPass = @newNumPassValue WHERE id = @wordId", conn);

                cmd.Parameters.AddWithValue("@newNumPassValue", newNumPassValue);
                cmd.Parameters.AddWithValue("@wordId", wordId);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateNumTested(int wordId, int newNumTestedValue)
        {
            using (MySqlConnection conn = new DataBaseConnector().GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE word SET numTested = @newNumTestedValue WHERE id = @wordId", conn);

                cmd.Parameters.AddWithValue("@newNumTestedValue", newNumTestedValue);
                cmd.Parameters.AddWithValue("@wordId", wordId);

                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateLiked(int wordId, Boolean liked)
        {
            using (MySqlConnection conn = new DataBaseConnector().GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE word SET `like` = @newLike WHERE id = @wordId", conn);

                cmd.Parameters.AddWithValue("@newLike", liked ? 1 : 0);
                cmd.Parameters.AddWithValue("@wordId", wordId);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateDeleted(int wordId, Boolean deleted)
        {
            using (MySqlConnection conn = new DataBaseConnector().GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE word SET `delete` = @newDelete WHERE id = @wordId", conn);

                cmd.Parameters.AddWithValue("@newDelete", deleted ? 1 : 0);
                cmd.Parameters.AddWithValue("@wordId", wordId);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
