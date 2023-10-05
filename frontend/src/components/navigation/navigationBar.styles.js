
const useStyles = (() => ({
    navlinks: {
      marginLeft: 20,
      display: "flex",
    },
   logo: {
      flexGrow: "1",
      cursor: "pointer",
    },
    link: {
      textDecoration: "none",
      color: "white",
      fontSize: "20px",
      marginLeft: 20,
      "&:hover": {
        color: "yellow",
        borderBottom: "1px solid white",
      },
    },
  }));

export default useStyles;