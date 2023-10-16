﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dysnomia
{
    public class Faung
    {
        public Fa Rod;
        public Fa Cone;

        public BigInteger Phi, Eta, Mu, Xi;
        public BigInteger Sigma, Rho, Upsilon, Ohm, Pi, Omicron, Omega;
        public short Chi;
        public delegate BigInteger Modulator(BigInteger A, BigInteger B, BigInteger C);
        Modulator Kappa;

        public Faung()
        {
            bool Failed = true;
            Kappa = Math.ModPow;
            while (Failed)
            {
                try
                {
                    Rod = new Fa();
                    Cone = new Fa();
                    OpenManifolds();
                    Failed = false;
                }
                catch (Exception E)
                {
                    continue;
                }
            }
        }

        public Faung(ref Fa Rod, ref Fa Cone, bool Refaung = true)
        {
            if (Refaung && (!Rod.Barn.IsZero || !Cone.Barn.IsZero))
                throw new Exception("Non Zero Barn");
            this.Rod = Rod;
            this.Cone = Cone;
            this.Cone.Kappa = -1;

            bool Failed = true;
            if(Refaung)
                Kappa = Math.ModPow;
            else
                Kappa = Math.ModXOR;

            while (Failed)
            {
                try
                {
                    OpenManifolds();
                    Failed = false;
                }
                catch (Exception E)
                {
                    this.Cone.Nu = 0;
                    throw;
                }
            }
            Rod.Gamma++;
            Cone.Gamma++;
        }

        public Faung(BigInteger Rho, BigInteger Upsilon, BigInteger Ohm, BigInteger Xi)
        {
            bool Failed = true;
            Kappa = Math.ModXOR;
            while (Failed)
            {
                try
                {
                    Rod = new Fa(true);
                    Cone = new Fa(true);
                    FuseAndOpen(Rho, Upsilon, Ohm, Xi);
                    Failed = false;
                }
                catch (Exception E)
                {
                    throw;
                }
            }
        }

        public Faung(ref Fa Beta, BigInteger Rho, BigInteger Upsilon, BigInteger Ohm, BigInteger Xi)
        {
            Rod = Beta;
            if (!Rod.Barn.IsZero)
                throw new Exception("Non Zero Barn");

            bool Failed = true;
            Kappa = Math.ModPow;
            while (Failed)
            {
                try
                {
                    Cone = new Fa();
                    Cone.Kappa = -1;
                    if (Rho == Ohm) Rho = Math.Random();
                    FuseAndOpen(Rho, Upsilon, Ohm, Xi);
                    Failed = false;
                }
                catch (Exception E)
                {
                    throw;
                }
            }
            Rod.Gamma++;
        }

        public void FuseAndOpen(BigInteger Rho, BigInteger Upsilon, BigInteger Ohm, BigInteger Xi)
        {
            Cone.Fuse(Rho, Upsilon, Ohm);
            Cone.Tune();
            OpenManifolds(Xi);
        }

        public void OpenManifolds()
        {
            Xi = Kappa(Cone.Signal, Rod.Channel, Math.Prime);
            OpenManifolds(Xi);
        }

        public void ConductorGenerate(BigInteger Xi)
        {
            Phi = Rod.Avail(Xi);
            Cone.Tau = Cone.Avail(Xi);

            Rod.Form(Cone.Tau);
            Cone.Form(Phi);

            Rod.Polarize();
            Cone.Polarize();
        }

        public void OpenManifolds(BigInteger Xi)
        {
            ConductorGenerate(Xi);

            Rod.Conjugate(ref Cone.Pole);
            Cone.Conjugate(ref Rod.Pole);

            if (Rod.Coordinate != Cone.Coordinate)
                throw new Exception("Bad Coordination");

            Cone.Conify();

            Eta = Rod.Saturate(Cone.Foundation, Cone.Channel);
            Mu = Cone.Saturate(Rod.Foundation, Rod.Channel);

            if (Rod.Element != Cone.Element)
                throw new Exception("Bad Element");

            Ratchet();

            Rod.Adduct(Cone.Dynamo);
            Cone.Adduct(Rod.Dynamo);

            Rod.Open();
            Cone.Open();

            if (!Cone.ManifoldCompare(ref Rod))
                throw new Exception("Bad Compare");
            this.Xi = Xi;
            Chi = 0;
        }

        public void Ratchet()
        {
            Rod.Bond();
            Cone.Bond();
        }

        public void Theta()
        {
            Theta(Pi > 0 ? Pi : Rod.Signal);
        }

        public void Lambda()
        {
            if (Chi != 3) throw new Exception("Chi Non 3");
            BigInteger Upsilon = Cone.Torque(Rod.Eta);
            BigInteger Ohm = Cone.Amplify(Upsilon);
            BigInteger Pi = Cone.Sustain(Ohm);
            Cone.React(Pi, Cone.Dynamo);
            Rod.React(Pi, Rod.Dynamo);
            Chi = 4;
        }

        public void Iota()
        {
            if (Chi != 2) throw new Exception("Chi Non 2");
            BigInteger Upsilon = Cone.Torque(Rod.Kappa);
            BigInteger Ohm = Cone.Amplify(Upsilon);
            BigInteger Pi = Cone.Sustain(Ohm);
            Rod.React(Pi, Rod.Channel);
            Cone.React(Pi, Cone.Channel);
            Chi = 3;
        }

        public void Beta(BigInteger Iota)
        {
            if (Iota == 0) throw new Exception("Iota Zero");
            if (Chi != 1) throw new Exception("Chi Non 1");
            BigInteger Upsilon = Rod.Torque(Iota);
            BigInteger Ohm = Rod.Amplify(Upsilon);
            BigInteger Pi = Rod.Sustain(Ohm);
            Rod.React(Pi, Cone.Dynamo);
            Cone.React(Pi, Rod.Dynamo);
            Chi = 2;
        }

        public void Theta(BigInteger Omicron)
        {
            if (Omicron == 0) throw new Exception("Omicron Zero");
            if (Chi != 0) throw new Exception("Chi Non Zero");
            bool Failed = true;
            while (Failed)
            {
                try
                {
                    Charge(Omicron);
                    if (Sigma < 4)
                        throw new Exception("Sigma Non 4");
                    Induce();
                    Torque();
                    Amplify();
                    Sustain();
                    React();
                    Failed = false;
                    Chi = 1;
                }
                catch (Exception E)
                {
                    throw E;
                }
            }
        }

        public void Charge(BigInteger Signal)
        {
            if (Signal == 0) throw new Exception("Signal Zero");
            Sigma = Cone.Charge(Signal);
        }

        public void Induce()
        {
            Rho = Rod.Induce(Sigma);
        }

        public void Torque()
        {
            Upsilon = Cone.Torque(Rho);
        }

        public void Amplify()
        {
            Ohm = Cone.Amplify(Upsilon);
        }

        public void Sustain()
        {
            Pi = Cone.Sustain(Ohm);
        }

        public void React()
        {
            Rod.React(Pi, Cone.Channel);
            Cone.React(Pi, Rod.Channel);
            if (Cone.Kappa != Rod.Eta || Rod.Kappa != Cone.Eta)
                throw new Exception("Non Match");
            if (Rod.Eta == Rod.Kappa)
                throw new Exception("Parallel");
            if (Cone.Kappa <= 1 && Rod.Kappa <= 1)
                throw new Exception("Negative");
            Omicron = Cone.Kappa;
            Omega = Rod.Kappa;
        }
    }
}
