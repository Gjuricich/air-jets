﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CabDominio;

namespace CabBusiness
{
    public class BookingBusiness
    {
        public List<Booking> List()
        {
            List<Booking> list = new List<Booking>();
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("SELECT * FROM Booking");
                dataManager.executeRead();
                while (dataManager.Lector.Read())
                {
                    Booking booking = new Booking();
                    booking.IdBooking = (int)(long)dataManager.Lector["IdBooking"];
                    booking.IdClient = (int)(long)dataManager.Lector["IdClient"];
                    booking.Origin.IdCity = (int)(long)dataManager.Lector["IdOrigen"];
                    booking.Destination.IdCity = (int)(long)dataManager.Lector["IdDestino"];
                    booking.SolicitudDate = (DateTime)dataManager.Lector["SolicitudDate"];
                    booking.DateBooking = (DateTime)dataManager.Lector["DateBooking"];
                    booking.Passengers = (int)dataManager.Lector["Passengers"];
                    booking.StateBooking = (string)dataManager.Lector["StateBooking"];
                    booking.State = (bool)dataManager.Lector["Estado"];

                    list.Add(booking);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                dataManager.closeConection();
            }
        }

        public void addBooking(Booking booking)
        {
            DataManager dataManager = new DataManager();

            try
            {

                dataManager.setQuery("INSERT INTO Booking(IdClient,IdOrigen,IdDestino,DateBooking,Passengers) VALUES (@IDCLIENT, @IDORIGEN,@IDDESTINO,  @PASAJEROS, @FECHARESERVA)");
                dataManager.setParameter("@IDCLIENT", booking.IdClient );
                dataManager.setParameter("@IDORIGEN", booking.Origin.IdCity);
                dataManager.setParameter("@IDDESTINO", booking.Destination.IdCity);
                dataManager.setParameter("@PASAJEROS",booking.Passengers );
                dataManager.setParameter("@FECHARESERVA", booking.DateBooking);
                dataManager.executeRead();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dataManager.closeConection();
            }
        }

    }
}
