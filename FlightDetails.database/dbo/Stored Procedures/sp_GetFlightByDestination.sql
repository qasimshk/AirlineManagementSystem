  CREATE Procedure sp_GetFlightByDestination  
  @Departure VARCHAR(3),
  @Arrival VARCHAR(3)
  AS
  BEGIN
	 SELECT fg.FlightNo, 
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureCountry,  
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalCountry,   
		fg.[Distance], 
		pm.ModelNumber,
		pm.[ManufacturerName],
		pm.[PlaneRange],
		pm.[CruiseSpeed]
	 FROM Flight fg
	 INNER JOIN PlaneModel pm ON fg.PlanModel=pm.ModelNumber
	 WHERE fg.[FlightDepartTo]=@Departure AND fg.FlightArriveFrom=@Arrival
  END