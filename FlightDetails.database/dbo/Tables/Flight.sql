CREATE TABLE [dbo].[Flight] (
    [FlightNo]         VARCHAR (10) NOT NULL,
    [FlightDepartTo]   CHAR (3)     NOT NULL,
    [FlightArriveFrom] CHAR (3)     NOT NULL,
    [Distance]         INT          NOT NULL,
    [PlanModel]        VARCHAR (10) NULL,
    CONSTRAINT [FlightNo_pk] PRIMARY KEY CLUSTERED ([FlightNo] ASC),
    CONSTRAINT [FlightArriveFrom] CHECK ([FlightArriveFrom]<>[FlightDepartTo]),
    CONSTRAINT [FLightArriceFrom_fk] FOREIGN KEY ([FlightArriveFrom]) REFERENCES [dbo].[Airport] ([AirportCode]),
    CONSTRAINT [FLightDepartTo_fk] FOREIGN KEY ([FlightDepartTo]) REFERENCES [dbo].[Airport] ([AirportCode])
);

