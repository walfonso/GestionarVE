namespace GestionarVE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CIUO",
                c => new
                    {
                        CiouID = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Description = c.String(),
                        Denomination = c.String(),
                    })
                .PrimaryKey(t => t.CiouID);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoID = c.Int(nullable: false, identity: true),
                        Descrption = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EstadoID);
            
            CreateTable(
                "dbo.pregunta",
                c => new
                    {
                        preguntaID = c.Int(nullable: false, identity: true),
                        VideoentrevistaID = c.Int(nullable: false),
                        orderPregID = c.Int(nullable: false),
                        description = c.String(),
                        VideoEntrevista_VEntrevistaID = c.Int(),
                    })
                .PrimaryKey(t => t.preguntaID)
                .ForeignKey("dbo.VideoEntrevista", t => t.VideoEntrevista_VEntrevistaID)
                .Index(t => t.VideoEntrevista_VEntrevistaID);
            
            CreateTable(
                "dbo.Preseleccionado",
                c => new
                    {
                        idPre = c.Int(nullable: false, identity: true),
                        codeKey = c.Int(nullable: false),
                        codeSolPer = c.Int(nullable: false),
                        fullname = c.String(),
                        email = c.String(),
                        SolicitudPersonal_SolPerID = c.Int(),
                    })
                .PrimaryKey(t => t.idPre)
                .ForeignKey("dbo.SolicitudPersonal", t => t.SolicitudPersonal_SolPerID)
                .Index(t => t.SolicitudPersonal_SolPerID);
            
            CreateTable(
                "dbo.SolicitudPersonal",
                c => new
                    {
                        SolPerID = c.Int(nullable: false, identity: true),
                        EmpresaID = c.Int(nullable: false),
                        CIOUID = c.Int(nullable: false),
                        Puesto = c.String(),
                        CantPuesto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SolPerID)
                .ForeignKey("dbo.CIUO", t => t.CIOUID, cascadeDelete: true)
                .Index(t => t.CIOUID);
            
            CreateTable(
                "dbo.VideoEntrevista",
                c => new
                    {
                        VEntrevistaID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        estado_EstadoID = c.Int(),
                        SolicitudPersonal_SolPerID = c.Int(),
                    })
                .PrimaryKey(t => t.VEntrevistaID)
                .ForeignKey("dbo.Estado", t => t.estado_EstadoID)
                .ForeignKey("dbo.SolicitudPersonal", t => t.SolicitudPersonal_SolPerID)
                .Index(t => t.estado_EstadoID)
                .Index(t => t.SolicitudPersonal_SolPerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoEntrevista", "SolicitudPersonal_SolPerID", "dbo.SolicitudPersonal");
            DropForeignKey("dbo.pregunta", "VideoEntrevista_VEntrevistaID", "dbo.VideoEntrevista");
            DropForeignKey("dbo.VideoEntrevista", "estado_EstadoID", "dbo.Estado");
            DropForeignKey("dbo.Preseleccionado", "SolicitudPersonal_SolPerID", "dbo.SolicitudPersonal");
            DropForeignKey("dbo.SolicitudPersonal", "CIOUID", "dbo.CIUO");
            DropIndex("dbo.VideoEntrevista", new[] { "SolicitudPersonal_SolPerID" });
            DropIndex("dbo.VideoEntrevista", new[] { "estado_EstadoID" });
            DropIndex("dbo.SolicitudPersonal", new[] { "CIOUID" });
            DropIndex("dbo.Preseleccionado", new[] { "SolicitudPersonal_SolPerID" });
            DropIndex("dbo.pregunta", new[] { "VideoEntrevista_VEntrevistaID" });
            DropTable("dbo.VideoEntrevista");
            DropTable("dbo.SolicitudPersonal");
            DropTable("dbo.Preseleccionado");
            DropTable("dbo.pregunta");
            DropTable("dbo.Estado");
            DropTable("dbo.CIUO");
        }
    }
}
