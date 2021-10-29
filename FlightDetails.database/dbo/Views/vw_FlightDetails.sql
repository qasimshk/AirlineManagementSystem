CREATE VIEW vw_FlightDetails 
AS
   SELECT fg.FlightNo, 
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureCountry,  
		(SELECT cy.CountryCode FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightDepartTo) AS DepartureCountryISO,
		(SELECT ap.AirportName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalAirport,  
		(SELECT cy.CountryName FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalCountry,   
		(SELECT cy.CountryCode FROM Airport ap INNER JOIN Country cy ON ap.CountryCode=cy.CountryCode WHERE ap.AirportCode=fg.FlightArriveFrom) AS ArrivalCountryISO,   
		fg.[Distance], 
		pm.ModelNumber,
		pm.[ManufacturerName],
		pm.[PlaneRange],
		pm.[CruiseSpeed]
	 FROM Flight fg
	 INNER JOIN PlaneModel pm ON fg.PlanModel=pm.ModelNumber