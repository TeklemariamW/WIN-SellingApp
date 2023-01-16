import { Counter } from "./components/Counter";
import { Customer } from "./components/Customer";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/allCustomers',
    element: <Customer />
  }
];

export default AppRoutes;
