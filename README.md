# Academy Scheduler Manager

![Techgroup Dapr](https://media.licdn.com/dms/image/D4D3DAQGVnCNKfv9bfQ/image-scale_191_1128/0/1675779502361?e=1693008000&v=beta&t=G2lc0TbIC6BEuMpiymhRdIojphS8IDXAjU9FmMFI8yU)

Academy Scheduler Manager is a robust academy scheduler manager designed to streamline the coordination and management of academic scheduling. It consists of three core microservices: Academy Manager, Study Scheduler, and Calendar. These microservices work together to provide a comprehensive solution for educational institutions.

## Microservices

1. **Academy Manager**: Manages all the academy-related information and activities.
2. **Study Scheduler**: Handles the scheduling of study sessions, classes, and other academic activities.
3. **Calendar**: Provides a unified calendar view for managing events, deadlines, and appointments.

## Prerequisites

- Docker
- Dapr CLI

## Getting Started

### Unix/Linux

1. **Clone the Repository**: Clone this repository to your local machine.
2. **Navigate to the Project Directory**: Open a terminal window and navigate to the project directory.
3. **Run the Shell Script**: Execute the `run.sh` script to start the project:

   ```bash
   ./run.sh
   ```

   This script will:

   - Start Docker Compose services.
   - Initialize Dapr.
   - Run the Techgroup Dapr microservices defined in `app.yml`.
   - Open the Dapr dashboard on port 9000.

### Windows

1. **Clone the Repository**: Clone this repository to your local machine.
2. **Navigate to the Project Directory**: Open a command prompt and navigate to the project directory.
3. **Run the Batch File**: Execute the `run.bat` script to start the project:

   ```bash
   run.bat
   ```

   This script will execute the same steps as the Unix/Linux version.

## Dapr Configuration

The Dapr configuration for Techgroup Dapr is defined in `app.yml`. This file outlines the configuration for the Academy Manager, Study Scheduler, and Calendar microservices.

## Contributing

- [@SebastianTorralba](https://github.com/SebastianTorralba) - Sebastian Torralba
- [@EugenioSerrano](https://github.com/EugenioSerrano) - Eugenio Serrano
- [@MateoCerquetella](https://github.com/mateocerquetella) - Mateo Cerquetella
- [@CamiloRossi](https://github.com/camilorossi) - Camilo Rossi
- [@Lnieto07](https://github.com/lnieto07) - Luis Nieto
- [@TadeoNavas](https://github.com/tadeoNavas) - Tadeo Navas

## License

This project is licensed under the GNU General Public License. See [LICENSE](LICENSE) for more details.
