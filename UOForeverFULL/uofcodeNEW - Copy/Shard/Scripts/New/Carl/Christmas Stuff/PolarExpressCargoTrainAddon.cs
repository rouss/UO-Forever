////////////////////////////////////////
//                                    //
//   Generated by CEO's YAAAG - V1.2  //
// (Yet Another Arya Addon Generator) //
//                                    //
////////////////////////////////////////

namespace Server.Items
{
    public class PolarExpressCargoTrainAddon : BaseAddon
    {
        private static int[,] m_AddOnSimpleComponents =
        {
            {6082, 1, -3, 36}, {6081, -1, -3, 36}, {6084, -1, 4, 36} // 132	133	134	
            , {6090, 1, -2, 36}, {6092, -1, 3, 36}, {6092, -1, 2, 36} // 140	142	143	
            , {6092, -1, 1, 36}, {6092, -1, 0, 36}, {6092, -1, -1, 36} // 144	145	146	
            , {6092, -1, -2, 36}, {6089, 0, -3, 36}, {6093, 0, -2, 36} // 147	148	150	
            , {6087, -1, -1, 36}, {6088, 1, -2, 36}, {9002, -1, -3, 15} // 153	154	166	
            , {3740, -1, -2, 15}, {8476, 1, 3, 14}, {3763, -1, -2, 19} // 168	172	173	
            , {3629, 0, 4, 15}, {5042, 0, -3, 13}, {3742, 0, -3, 13} // 174	175	176	
            , {9007, 2, 2, 22}, {4167, -1, 3, 13}, {5644, -1, 2, 15} // 177	178	179	
            , {5644, -1, 0, 15} // 180	
        };


        public override BaseAddonDeed Deed { get { return new PolarExpressCargoTrainAddonDeed(); } }

        [Constructable]
        public PolarExpressCargoTrainAddon()
        {
            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
            {
                AddComponent(new AddonComponent(m_AddOnSimpleComponents[i, 0]), m_AddOnSimpleComponents[i, 1],
                    m_AddOnSimpleComponents[i, 2], m_AddOnSimpleComponents[i, 3]);
            }


            AddComplexComponent(this, 11580, 1, -2, 9, 33, -1, "Polar Express Train", 1); // 1
            AddComplexComponent(this, 6093, -2, -1, 24, 0, -1, "Polar Express Train", 1); // 2
            AddComplexComponent(this, 1981, 0, -2, 7, 1108, -1, "Polar Express Train", 1); // 3
            AddComplexComponent(this, 11581, 0, 4, 9, 33, -1, "Polar Express Cargo Train", 1); // 4
            AddComplexComponent(this, 11580, -2, 0, 9, 33, -1, "Polar Express Train", 1); // 5
            AddComplexComponent(this, 1981, 1, 0, 7, 1108, -1, "Polar Express Cargo Train", 1); // 6
            AddComplexComponent(this, 893, -1, 0, 8, 1107, -1, "Polar Express Train", 1); // 7
            AddComplexComponent(this, 11580, -2, -2, 9, 33, -1, "Polar Express Train", 1); // 8
            AddComplexComponent(this, 11583, 1, -4, 9, 33, -1, "Polar Express Train", 1); // 9
            AddComplexComponent(this, 11581, 0, -4, 9, 33, -1, "Polar Express Train", 1); // 10
            AddComplexComponent(this, 11580, 1, -1, 9, 33, -1, "Polar Express Cargo Train", 1); // 11
            AddComplexComponent(this, 11583, -1, -4, 9, 33, -1, "Polar Express Train", 1); // 12
            AddComplexComponent(this, 1981, -1, -2, 7, 1108, -1, "Polar Express Train", 1); // 13
            AddComplexComponent(this, 1981, -1, -3, 7, 1108, -1, "Polar Express Train", 1); // 14
            AddComplexComponent(this, 1981, 1, 1, 7, 1108, -1, "Polar Express Cargo Train", 1); // 15
            AddComplexComponent(this, 6276, 3, -1, 11, 2101, -1, "Polar Express Cargo Train", 1); // 16
            AddComplexComponent(this, 11580, 1, 3, 9, 33, -1, "Polar Express Cargo Train", 1); // 17
            AddComplexComponent(this, 1981, 1, -2, 7, 1108, -1, "Polar Express Train", 1); // 18
            AddComplexComponent(this, 11580, -2, -1, 9, 33, -1, "Polar Express Train", 1); // 19
            AddComplexComponent(this, 11582, 1, -3, 9, 33, -1, "Polar Express Train", 1); // 20
            AddComplexComponent(this, 4269, 3, 4, 0, 2101, -1, "Polar Express Cargo Train", 1); // 21
            AddComplexComponent(this, 6276, 3, 3, 10, 2101, -1, "Polar Express Cargo Train", 1); // 22
            AddComplexComponent(this, 1981, -1, -1, 7, 1108, -1, "Polar Express Train", 1); // 23
            AddComplexComponent(this, 11580, 1, 2, 9, 33, -1, "Polar Express Cargo Train", 1); // 24
            AddComplexComponent(this, 11580, -2, 1, 9, 33, -1, "Polar Express Train", 1); // 25
            AddComplexComponent(this, 1981, -1, 0, 7, 1108, -1, "Polar Express Train", 1); // 26
            AddComplexComponent(this, 7883, 0, 5, 9, 1109, -1, "Polar Express Cargo Train", 1); // 27
            AddComplexComponent(this, 1981, 1, -1, 7, 1108, -1, "Polar Express Cargo Train", 1); // 28
            AddComplexComponent(this, 1981, 0, -1, 7, 1108, -1, "Polar Express Cargo Train", 1); // 29
            AddComplexComponent(this, 5718, 2, -2, 8, 1102, -1, "wheel", 1); // 30
            AddComplexComponent(this, 5718, 2, -1, 8, 1102, -1, "Polar Express Cargo Train", 1); // 31
            AddComplexComponent(this, 6276, 3, -2, 11, 2101, -1, "wheel", 1); // 32
            AddComplexComponent(this, 6276, 3, 4, 10, 2101, -1, "Polar Express Cargo Train", 1); // 33
            AddComplexComponent(this, 4269, 3, -1, 1, 2101, -1, "Polar Express Cargo Train", 1); // 34
            AddComplexComponent(this, 1981, 1, -3, 7, 1108, -1, "Polar Express Train", 1); // 35
            AddComplexComponent(this, 11548, -2, 1, 9, 33, -1, "Polar Express Train", 1); // 36
            AddComplexComponent(this, 11548, -2, -1, 9, 33, -1, "Polar Express Train", 1); // 37
            AddComplexComponent(this, 11548, 1, -1, 9, 33, -1, "Polar Express Cargo Train", 1); // 38
            AddComplexComponent(this, 11548, 1, 1, 9, 33, -1, "Polar Express Cargo Train", 1); // 39
            AddComplexComponent(this, 11582, -2, -3, 9, 33, -1, "Polar Express Train", 1); // 40
            AddComplexComponent(this, 1981, -1, 1, 7, 1108, -1, "Polar Express Train", 1); // 41
            AddComplexComponent(this, 1981, 0, 0, 7, 1108, -1, "Polar Express Cargo Train", 1); // 42
            AddComplexComponent(this, 1981, 0, 1, 7, 1108, -1, "Polar Express Cargo Train", 1); // 43
            AddComplexComponent(this, 1981, -1, 4, 7, 1108, -1, "Polar Express Train", 1); // 44
            AddComplexComponent(this, 1981, -1, 3, 7, 1108, -1, "Polar Express Train", 1); // 45
            AddComplexComponent(this, 1981, -1, 2, 7, 1108, -1, "Polar Express Train", 1); // 46
            AddComplexComponent(this, 1981, 0, 2, 7, 1108, -1, "Polar Express Cargo Train", 1); // 47
            AddComplexComponent(this, 1981, 0, 3, 7, 1108, -1, "Polar Express Cargo Train", 1); // 48
            AddComplexComponent(this, 1981, 0, 4, 7, 1108, -1, "Polar Express Cargo Train", 1); // 49
            AddComplexComponent(this, 1981, 1, 2, 7, 1108, -1, "Polar Express Cargo Train", 1); // 50
            AddComplexComponent(this, 1981, 1, 3, 7, 1108, -1, "Polar Express Cargo Train", 1); // 51
            AddComplexComponent(this, 1981, 1, 4, 7, 1108, -1, "Polar Express Cargo Train", 1); // 52
            AddComplexComponent(this, 5718, 2, 3, 8, 1102, -1, "Polar Express Cargo Train", 1); // 53
            AddComplexComponent(this, 11548, -2, -4, 9, 33, -1, "Polar Express Train", 1); // 54
            AddComplexComponent(this, 11582, -2, 4, 9, 33, -1, "Polar Express Train", 1); // 55
            AddComplexComponent(this, 11545, 1, 4, 9, 33, -1, "Polar Express Cargo Train", 1); // 56
            AddComplexComponent(this, 11583, -1, 4, 9, 33, -1, "Polar Express Train", 1); // 57
            AddComplexComponent(this, 2170, 2, 0, 4, 2101, -1, "Polar Express Cargo Train", 1); // 58
            AddComplexComponent(this, 11580, -2, 2, 9, 33, -1, "Polar Express Train", 1); // 59
            AddComplexComponent(this, 11580, -2, 3, 9, 33, -1, "Polar Express Train", 1); // 60
            AddComplexComponent(this, 5718, 2, 4, 8, 1102, -1, "Polar Express Cargo Train", 1); // 61
            AddComplexComponent(this, 1981, 0, -3, 7, 1108, -1, "Polar Express Train", 1); // 62
            AddComplexComponent(this, 893, -1, 1, 8, 1107, -1, "Polar Express Train", 1); // 63
            AddComplexComponent(this, 4269, 3, 3, 0, 2101, -1, "Polar Express Cargo Train", 1); // 64
            AddComplexComponent(this, 892, 1, 5, 8, 1107, -1, "Polar Express Cargo Train", 1); // 65
            AddComplexComponent(this, 893, -1, -1, 8, 1107, -1, "Polar Express Train", 1); // 66
            AddComplexComponent(this, 893, -1, 3, 8, 1107, -1, "Polar Express Train", 1); // 67
            AddComplexComponent(this, 893, -1, 2, 8, 1107, -1, "Polar Express Train", 1); // 68
            AddComplexComponent(this, 892, 1, -3, 8, 1107, -1, "Polar Express Train", 1); // 69
            AddComplexComponent(this, 893, -1, 4, 8, 1107, -1, "Polar Express Train", 1); // 70
            AddComplexComponent(this, 6276, 3, 2, 10, 2101, -1, "Polar Express Cargo Train", 1); // 71
            AddComplexComponent(this, 5718, 2, 2, 9, 1102, -1, "Polar Express Cargo Train", 1); // 72
            AddComplexComponent(this, 3024, 3, 0, 13, 1260, -1, "Polar Express Cargo Train", 1); // 73
            AddComplexComponent(this, 2903, -1, -1, 9, 1368, -1, "", 1); // 74
            AddComplexComponent(this, 2903, -1, 1, 9, 1368, -1, "", 1); // 75
            AddComplexComponent(this, 11549, 1, 4, 14, 33, -1, "Polar Express Cargo Train", 1); // 76
            AddComplexComponent(this, 11549, -2, 4, 14, 33, -1, "", 1); // 77
            AddComplexComponent(this, 11549, 1, -4, 14, 33, -1, "", 1); // 78
            AddComplexComponent(this, 11549, -2, -4, 14, 33, -1, "", 1); // 79
            AddComplexComponent(this, 1981, 0, 4, 34, 1368, -1, "Polar Express Cargo Train", 1); // 80
            AddComplexComponent(this, 1981, -1, 4, 34, 1368, -1, "", 1); // 81
            AddComplexComponent(this, 1981, 1, 3, 34, 1368, -1, "Polar Express Cargo Train", 1); // 82
            AddComplexComponent(this, 1981, 1, 4, 34, 1368, -1, "Polar Express Cargo Train", 1); // 83
            AddComplexComponent(this, 1981, -1, -3, 34, 1368, -1, "", 1); // 84
            AddComplexComponent(this, 1981, -1, -2, 34, 1368, -1, "", 1); // 85
            AddComplexComponent(this, 1981, -1, -1, 34, 1368, -1, "", 1); // 86
            AddComplexComponent(this, 1981, -1, 0, 34, 1368, -1, "", 1); // 87
            AddComplexComponent(this, 1981, -1, 1, 34, 1368, -1, "", 1); // 88
            AddComplexComponent(this, 1981, -1, 2, 34, 1368, -1, "", 1); // 89
            AddComplexComponent(this, 1981, -1, 3, 34, 1368, -1, "", 1); // 90
            AddComplexComponent(this, 1981, 0, -3, 34, 1368, -1, "", 1); // 91
            AddComplexComponent(this, 1981, 0, -2, 34, 1368, -1, "", 1); // 92
            AddComplexComponent(this, 1981, 0, -1, 34, 1368, -1, "Polar Express Cargo Train", 1); // 93
            AddComplexComponent(this, 1981, 0, 0, 34, 1368, -1, "Polar Express Cargo Train", 1); // 94
            AddComplexComponent(this, 1981, 0, 1, 34, 1368, -1, "Polar Express Cargo Train", 1); // 95
            AddComplexComponent(this, 1981, 0, 2, 34, 1368, -1, "Polar Express Cargo Train", 1); // 96
            AddComplexComponent(this, 1981, 0, 3, 34, 1368, -1, "Polar Express Cargo Train", 1); // 97
            AddComplexComponent(this, 1981, 1, -3, 34, 1368, -1, "", 1); // 98
            AddComplexComponent(this, 1981, 1, -2, 34, 1368, -1, "", 1); // 99
            AddComplexComponent(this, 1981, 1, -1, 34, 1368, -1, "Polar Express Cargo Train", 1); // 100
            AddComplexComponent(this, 1981, 1, 0, 34, 1368, -1, "Polar Express Cargo Train", 1); // 101
            AddComplexComponent(this, 1981, 1, 1, 34, 1368, -1, "Polar Express Cargo Train", 1); // 102
            AddComplexComponent(this, 1981, 1, 2, 34, 1368, -1, "Polar Express Cargo Train", 1); // 103
            AddComplexComponent(this, 893, 0, -1, 38, 1153, -1, "Polar Express Cargo Train", 1); // 104
            AddComplexComponent(this, 893, 0, 0, 38, 1153, -1, "Polar Express Cargo Train", 1); // 105
            AddComplexComponent(this, 893, 0, 1, 38, 1153, -1, "Polar Express Cargo Train", 1); // 106
            AddComplexComponent(this, 893, 0, 2, 38, 1153, -1, "Polar Express Cargo Train", 1); // 107
            AddComplexComponent(this, 893, 0, 3, 38, 1153, -1, "Polar Express Cargo Train", 1); // 108
            AddComplexComponent(this, 893, 0, 4, 38, 1153, -1, "Polar Express Cargo Train", 1); // 109
            AddComplexComponent(this, 893, 0, 5, 38, 1153, -1, "Polar Express Cargo Train", 1); // 110
            AddComplexComponent(this, 892, 1, -2, 38, 1153, -1, "", 1); // 111
            AddComplexComponent(this, 892, 3, -2, 38, 1153, -1, "", 1); // 112
            AddComplexComponent(this, 892, 2, -2, 38, 1153, -1, "", 1); // 113
            AddComplexComponent(this, 893, 2, -1, 6, 1106, -1, "Polar Express Cargo Train", 1); // 114
            AddComplexComponent(this, 893, 2, 0, 6, 1106, -1, "Polar Express Cargo Train", 1); // 115
            AddComplexComponent(this, 893, 2, 3, 6, 1106, -1, "Polar Express Cargo Train", 1); // 116
            AddComplexComponent(this, 893, 2, 4, 6, 1106, -1, "Polar Express Cargo Train", 1); // 117
            AddComplexComponent(this, 2879, -1, 0, 9, 1102, -1, "", 1); // 118
            AddComplexComponent(this, 2879, -1, 2, 9, 1102, -1, "", 1); // 119
            AddComplexComponent(this, 2903, 0, 0, 9, 1368, -1, "Polar Express Cargo Train", 1); // 120
            AddComplexComponent(this, 2878, 1, -3, 7, 1369, -1, "", 1); // 121
            AddComplexComponent(this, 2878, -1, -3, 7, 1369, -1, "", 1); // 122
            AddComplexComponent(this, 2878, -1, -2, 7, 1369, -1, "", 1); // 123
            AddComplexComponent(this, 2878, 0, -3, 7, 1369, -1, "", 1); // 124
            AddComplexComponent(this, 2878, -1, 3, 7, 1369, -1, "", 1); // 125
            AddComplexComponent(this, 2878, 1, 4, 7, 1369, -1, "Polar Express Cargo Train", 1); // 126
            AddComplexComponent(this, 2878, -1, 4, 7, 1369, -1, "", 1); // 127
            AddComplexComponent(this, 2878, 0, 4, 7, 1369, -1, "Polar Express Cargo Train", 1); // 128
            AddComplexComponent(this, 2878, 0, 3, 7, 1369, -1, "Polar Express Cargo Train", 1); // 129
            AddComplexComponent(this, 2878, 1, 3, 7, 1369, -1, "Polar Express Cargo Train", 1); // 130
            AddComplexComponent(this, 6083, 1, 4, 36, 0, -1, "Polar Express Cargo Train", 1); // 131
            AddComplexComponent(this, 6090, 1, 3, 36, 0, -1, "Polar Express Cargo Train", 1); // 135
            AddComplexComponent(this, 6090, 1, 2, 36, 0, -1, "Polar Express Cargo Train", 1); // 136
            AddComplexComponent(this, 6090, 1, 1, 36, 0, -1, "Polar Express Cargo Train", 1); // 137
            AddComplexComponent(this, 6090, 1, 0, 36, 0, -1, "Polar Express Cargo Train", 1); // 138
            AddComplexComponent(this, 6090, 1, -1, 36, 0, -1, "Polar Express Cargo Train", 1); // 139
            AddComplexComponent(this, 6091, 0, 4, 36, 0, -1, "Polar Express Cargo Train", 1); // 141
            AddComplexComponent(this, 6093, 0, 3, 36, 0, -1, "Polar Express Cargo Train", 1); // 149
            AddComplexComponent(this, 6094, 0, 1, 36, 0, -1, "Polar Express Cargo Train", 1); // 151
            AddComplexComponent(this, 6094, 0, 0, 36, 0, -1, "Polar Express Cargo Train", 1); // 152
            AddComplexComponent(this, 6086, 0, 4, 36, 0, -1, "Polar Express Cargo Train", 1); // 155
            AddComplexComponent(this, 6085, 1, 1, 36, 0, -1, "Polar Express Cargo Train", 1); // 156
            AddComplexComponent(this, 6085, 0, 3, 36, 0, -1, "Polar Express Cargo Train", 1); // 157
            AddComplexComponent(this, 6086, 1, 3, 36, 0, -1, "Polar Express Cargo Train", 1); // 158
            AddComplexComponent(this, 6087, 1, 4, 36, 0, -1, "Polar Express Cargo Train", 1); // 159
            AddComplexComponent(this, 6088, 0, 4, 36, 0, -1, "Polar Express Cargo Train", 1); // 160
            AddComplexComponent(this, 6088, 2, 2, 6, 0, -1, "Polar Express Cargo Train", 1); // 161
            AddComplexComponent(this, 6088, 2, 3, 6, 0, -1, "Polar Express Cargo Train", 1); // 162
            AddComplexComponent(this, 4653, 0, 1, 36, 1153, -1, "snow", 1); // 163
            AddComplexComponent(this, 11549, 1, 1, 13, 33, -1, "Polar Express Cargo Train", 1); // 164
            AddComplexComponent(this, 11549, 1, -1, 13, 33, -1, "Polar Express Cargo Train", 1); // 165
            AddComplexComponent(this, 9002, -1, -3, 18, 32, -1, "", 1); // 167
            AddComplexComponent(this, 5363, 0, -3, 13, 0, -1, "toy boat", 1); // 169
            AddComplexComponent(this, 8472, 0, 3, 14, 0, -1, "Teddy Bear", 1); // 170
            AddComplexComponent(this, 7712, -1, 3, 13, 0, -1, "Christmas Stories", 1); // 171
        }

        public PolarExpressCargoTrainAddon(Serial serial) : base(serial)
        {}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset,
            int hue, int lightsource, string name = null, int amount = 1)
        {
            AddonComponent ac = new AddonComponent(item);
            if (!string.IsNullOrEmpty(name))
            {
                ac.Name = name;
            }
            if (hue != 0)
            {
                ac.Hue = hue;
            }
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
            {
                ac.Light = (LightType) lightsource;
            }
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

    public class PolarExpressCargoTrainAddonDeed : BaseAddonDeed
    {
        public override BaseAddon Addon { get { return new PolarExpressCargoTrainAddon(); } }

        [Constructable]
        public PolarExpressCargoTrainAddonDeed()
        {
            Name = "PolarExpressCargoTrain";
        }

        public PolarExpressCargoTrainAddonDeed(Serial serial) : base(serial)
        {}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}