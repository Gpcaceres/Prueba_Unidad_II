using System;
using System.Collections.Generic;
using GestionCitasMedicas;
using Xunit;
using static GestionCitasMedicas.Entidades;

namespace TestGestionCitasMedicas
{
    public class EntidadesPruebas
    {
        // Prueba para la clase Paciente
        [Fact]
        public void CrearPaciente_DeberiaTenerTelefonoValido()
        {
            // Arrange
            var paciente = new Paciente
            {
                IdPaciente = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Telefono = "123-456-789"
            };

            // Act & Assert: Verificar que el teléfono se establece correctamente
            Assert.Equal("123-456-789", paciente.Telefono);
        }

        [Fact]
        public void PacienteTelefonoInvalido_DeberiaLanzarExcepcion()
        {
            // Arrange
            var paciente = new Paciente
            {
                IdPaciente = 1,
                Nombre = "Juan",
                Apellido = "Pérez"
            };

            // Act & Assert: Verificar que se lanza la excepción al establecer un teléfono inválido
            var ex = Assert.Throws<ArgumentException>(() => paciente.Telefono = "123");
            Assert.Equal("El teléfono no es válido.", ex.Message);
        }

        [Fact]
        public void CrearPaciente_DeberiaInicializarCitasComoListaVacia()
        {
            // Arrange
            var paciente = new Paciente
            {
                IdPaciente = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Telefono = "123-456-789"
            };

            // Act & Assert: Verificar que la lista de citas está vacía inicialmente
            Assert.Empty(paciente.Citas);
        }

        // Prueba para la clase Doctor
        [Fact]
        public void CrearDoctor_DeberiaTenerEspecialidad()
        {
            // Arrange
            var doctor = new Doctor
            {
                IdDoctor = 1,
                Nombre = "Dr. Gómez",
                Especialidad = "Cardiología"
            };

            // Act & Assert: Verificar que la especialidad del doctor es correcta
            Assert.Equal("Cardiología", doctor.Especialidad);
        }

        [Fact]
        public void CrearDoctor_DeberiaInicializarCitasComoListaVacia()
        {
            // Arrange
            var doctor = new Doctor
            {
                IdDoctor = 1,
                Nombre = "Dr. Gómez",
                Especialidad = "Cardiología"
            };

            // Act & Assert: Verificar que la lista de citas está vacía inicialmente
            Assert.Empty(doctor.Citas);
        }

        // Prueba para la clase Cita
        [Fact]
        public void CrearCita_DeberiaEstablecerFechaYRelacionConPacienteYDoctor()
        {
            // Arrange
            var cita = new Cita
            {
                IdCita = 1,
                Fecha = new DateTime(2025, 1, 21),
                IdPaciente = 1,
                IdDoctor = 1
            };

            // Act & Assert: Verificar que la cita tiene la fecha y los ID correctos
            Assert.Equal(new DateTime(2025, 1, 21), cita.Fecha);
            Assert.Equal(1, cita.IdPaciente);
            Assert.Equal(1, cita.IdDoctor);
        }

        [Fact]
        public void CrearCita_DeberiaInicializarProcedimientosComoListaVacia()
        {
            // Arrange
            var cita = new Cita
            {
                IdCita = 1,
                Fecha = new DateTime(2025, 1, 21),
                IdPaciente = 1,
                IdDoctor = 1
            };

            // Act & Assert: Verificar que la lista de procedimientos está vacía inicialmente
            Assert.Empty(cita.Procedimientos);
        }

        // Prueba para la clase Procedimiento
        [Fact]
        public void CrearProcedimiento_DeberiaTenerDescripcionYCosto()
        {
            // Arrange
            var procedimiento = new Procedimiento
            {
                IdProcedimiento = 1,
                Descripcion = "Consulta general",
                Costo = 150.50m,
                IdCita = 1
            };

            // Act & Assert: Verificar que el procedimiento tiene la descripción y costo correctos
            Assert.Equal("Consulta general", procedimiento.Descripcion);
            Assert.Equal(150.50m, procedimiento.Costo);
        }

        [Fact]
        public void CrearProcedimiento_DeberiaEstablecerCita()
        {
                // Arrange
                var cita = new Cita { IdCita = 1, Fecha = DateTime.Now, IdPaciente = 1, IdDoctor = 1 };
                var procedimiento = new Procedimiento
                {
                    IdProcedimiento = 1,
                    Descripcion = "Consulta general",
                    Costo = 150.50m,
                    IdCita = 1, // Asegúrate de asignar IdCita aquí
                    Cita = cita
                };
                Assert.Equal(cita, procedimiento.Cita);
            }
        }
}
