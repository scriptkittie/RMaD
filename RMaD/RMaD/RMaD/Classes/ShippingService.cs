﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMaD.Classes
{
    internal class ShippingService
    {
        private static SQLiteDataReader result;
        private static SQLiteCommand sqlCommand;
        static string sqlQuery;

        public List<string> loadShippingServList()
        {
            List<string> shippingServList = new List<string>();

            DatabaseAccess databaseObject = new DatabaseAccess();
            sqlQuery = "SELECT SHIPPING_COMPANY_Name from SHIPPING_COMPANY";
            sqlCommand = new SQLiteCommand(sqlQuery, databaseObject.sqlConnection);
            //sqlCommand.Parameters.AddWithValue("@projectVer", projectVer);

            databaseObject.OpenConnection();
            result = sqlCommand.ExecuteReader();

            //int moduleID = 0;

            if (result.HasRows)
            {
                while (result.Read())
                {
                    shippingServList.Add(result[0].ToString());
                }
            }

            result.Close();
            databaseObject.CloseConnection();

            return shippingServList;
        }
        //Get carried ID from database
        public int getCarrierID(string carrierName)
        {
            DatabaseAccess databaseObject = new DatabaseAccess();
            sqlQuery = "select shipping_company_id from SHIPPING_COMPANY where shipping_company_name = @carrier";
            sqlCommand = new SQLiteCommand(sqlQuery, databaseObject.sqlConnection);
            sqlCommand.Parameters.AddWithValue("@carrier", carrierName);
            databaseObject.OpenConnection();

            result = sqlCommand.ExecuteReader();

            int carrierID = 0;

            if (result.HasRows)
            {
                if (result.Read())
                {
                    if (result[0].ToString() == string.Empty)
                    {
                        result.Close();
                        databaseObject.CloseConnection();
                        return 0;
                    }

                    carrierID = int.Parse(result[0].ToString());
                }
            }

            result.Close();
            databaseObject.CloseConnection();

            return carrierID;
        }

        //Get shipment status ID from database
        public int getShipmentStatusID(string shipmentStatus)
        {
            DatabaseAccess databaseObject = new DatabaseAccess();
            sqlQuery = "select shipment_status_id from SHIPMENT_STATUS where status = @shipStatus";
            sqlCommand = new SQLiteCommand(sqlQuery, databaseObject.sqlConnection);
            sqlCommand.Parameters.AddWithValue("@shipStatus", shipmentStatus);
            databaseObject.OpenConnection();

            result = sqlCommand.ExecuteReader();

            int shipmentStatusId = 0;

            if (result.HasRows)
            {
                if (result.Read())
                {
                    if (result[0].ToString() == string.Empty)
                    {
                        result.Close();
                        databaseObject.CloseConnection();
                        return 0;
                    }

                    shipmentStatusId = int.Parse(result[0].ToString());
                }
            }

            result.Close();
            databaseObject.CloseConnection();

            return shipmentStatusId;
        }

        public List<string> loadShippingStatusList()
        {
            List<string> statusList = new List<string>();

            DatabaseAccess databaseObject = new DatabaseAccess();
            sqlQuery = "SELECT status from SHIPMENT_STATUS";
            sqlCommand = new SQLiteCommand(sqlQuery, databaseObject.sqlConnection);
            //sqlCommand.Parameters.AddWithValue("@projectVer", projectVer);

            databaseObject.OpenConnection();
            result = sqlCommand.ExecuteReader();

            //int moduleID = 0;

            if (result.HasRows)
            {
                while (result.Read())
                {
                    statusList.Add(result[0].ToString());
                }
            }

            result.Close();
            databaseObject.CloseConnection();

            return statusList;
        }

    }
}
